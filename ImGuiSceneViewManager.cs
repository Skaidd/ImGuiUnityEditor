using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace ImGuiUnityEditor
{
    [InitializeOnLoad]
    internal class ImGuiSceneViewManager
    {
        private static readonly Dictionary<SceneView, ImGuiRendererContainer> _sceneViewRenderers = new();
        private static readonly Dictionary<SceneView, List<ImGuiSceneView>> _sceneViewElementsMap = new();
        private static readonly TypeCache.TypeCollection _sceneViewElementTypes = new();

        static ImGuiSceneViewManager()
        {
            _sceneViewElementTypes = TypeCache.GetTypesDerivedFrom<ImGuiSceneView>();
            SceneView.duringSceneGui += OnSceneViewGUI;
        }

        private static string GetMenuPath(ImGuiSceneView sceneView)
        {
            ImGuiMenuAttribute attribute = (ImGuiMenuAttribute)sceneView.GetType().
            GetCustomAttributes(typeof(ImGuiMenuAttribute), false).FirstOrDefault();
            if (attribute != null && !string.IsNullOrEmpty(attribute.ItemName))
            {
                return attribute.ItemName;
            }
            return null;
        }

        private static void UpdateMenuCheckmark(ImGuiSceneView sceneView, bool state)
        {
            string menuPath = GetMenuPath(sceneView);
            if (!string.IsNullOrEmpty(menuPath))
            {
                Menu.SetChecked(menuPath, state);
            }
        }

        public static void Toggle<T>() where T : ImGuiSceneView
        {
            var sceneView = GetSceneView(typeof(T));
            if (sceneView != null)
            {
                sceneView.IsEnabled = !sceneView.IsEnabled;
                UpdateMenuCheckmark(sceneView, sceneView.IsEnabled);
            }
        }

        public static void Toggle(Type sceneViewType)
        {
            if (sceneViewType != null)
            {
                var sceneView = GetSceneView(sceneViewType);
                if (sceneView != null)
                {
                    sceneView.IsEnabled = !sceneView.IsEnabled;
                    UpdateMenuCheckmark(sceneView, sceneView.IsEnabled);
                }
            }
        }

        public static ImGuiSceneView SetEnabled<T>(bool enabled) where T : ImGuiSceneView
        {
            return SetEnabled(typeof(T), enabled);
        }

        public static ImGuiSceneView SetEnabled(Type sceneViewType, bool enabled)
        {
            if (sceneViewType != null)
            {
                var sceneView = GetSceneView(sceneViewType);
                if (sceneView != null)
                {
                    sceneView.IsEnabled = enabled;
                    UpdateMenuCheckmark(sceneView, enabled);
                    return sceneView;
                }
            }
            return null;
        }

        public static ImGuiSceneView GetSceneView<T>() where T : ImGuiSceneView
        {
            return GetSceneView(typeof(T));
        }

        public static ImGuiSceneView GetSceneView(Type sceneViewType)
        {
            if (sceneViewType != null)
            {
                return _sceneViewElementsMap.First().Value.FirstOrDefault(e => e.GetType() == sceneViewType);
            }
            return null;
        }

        private static List<ImGuiSceneView> CreateSceneViewElementsForSceneView()
        {
            var elements = new List<ImGuiSceneView>();

            foreach (var type in _sceneViewElementTypes)
            {
                if (Activator.CreateInstance(type) is ImGuiSceneView instance)
                {
                    elements.Add(instance);
                }
                else
                {
                    Debug.LogError($"Failed to create instance of {type.Name}");
                }
            }
            return elements;
        }

        private static void OnSceneViewGUI(SceneView sceneView)
        {
            EnsureRendererForSceneView(sceneView);
            if (_sceneViewRenderers.TryGetValue(sceneView, out var renderer))
            {
                renderer.Draw();
                sceneView.Repaint();
            }
        }

        private static void EnsureRendererForSceneView(SceneView view)
        {
            if (!_sceneViewRenderers.ContainsKey(view))
            {
                var imguiRendererContainer = new ImGuiRendererContainer();

                var elements = CreateSceneViewElementsForSceneView();
                _sceneViewElementsMap[view] = elements;

                foreach (var element in elements)
                {
                    element.SetContainer(imguiRendererContainer);
                    var _hasMenuAttribute = element.GetType().GetCustomAttributes(typeof(ImGuiMenuAttribute), false).Length > 0;
                    element.IsEnabled = !_hasMenuAttribute;
                }

                _sceneViewRenderers.Add(view, imguiRendererContainer);
                view.rootVisualElement.Add(imguiRendererContainer);
            }
        }
    }
}