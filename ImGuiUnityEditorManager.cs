using System;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace ImGuiUnityEditor
{
    /// <summary>
    /// Manages ImGui objects in the Unity Editor.
    /// </summary>
    [InitializeOnLoad]
    public class ImGuiUnityEditorManager
    {
        /// <summary>
        /// Opens/Shows an ImGui object
        /// </summary>
        /// <typeparam name="T">The type of ImGui object to open</typeparam>
        /// <returns>The instance of the object that was opened</returns>
        public static T Open<T>() where T : class, IImGuiObject
        {
            if (typeof(ImGuiEditorWindow).IsAssignableFrom(typeof(T)))
            {
                var window = default(T);
                EditorApplication.delayCall += () =>
                {
                    window = EditorWindow.GetWindow(typeof(T)) as T;
                };
                return window;
            }
            else if (typeof(ImGuiSceneView).IsAssignableFrom(typeof(T)))
            {
                return ImGuiSceneViewManager.SetEnabled(typeof(T), true) as T;
            }
            else
            {
                throw new InvalidOperationException($"Type {typeof(T)} is not a valid ImGuiEditorWindow or ImGuiSceneView");
            }
        }

        /// <summary>
        /// Closes an ImGui object
        /// </summary>
        /// <typeparam name="T">The type of ImGui object to close</typeparam>
        public static void Close<T>() where T : class, IImGuiObject
        {
            if (typeof(ImGuiEditorWindow).IsAssignableFrom(typeof(T)))
            {
                EditorApplication.delayCall += () =>
                {
                    var window = EditorWindow.GetWindow(typeof(T));
                    window.Close();
                };
            }
            else if (typeof(ImGuiSceneView).IsAssignableFrom(typeof(T)))
            {
                ImGuiSceneViewManager.SetEnabled(typeof(T), false);
            }
            else
            {
                throw new InvalidOperationException($"Type {typeof(T)} is not a valid ImGuiEditorWindow or ImGuiSceneView");
            }
        }

        /// <summary>
        /// Toggles an ImGui object between open and closed states
        /// </summary>
        /// <typeparam name="T">The type of ImGui object to toggle</typeparam>
        public static void Toggle<T>() where T : class, IImGuiObject
        {
            if (typeof(ImGuiEditorWindow).IsAssignableFrom(typeof(T)))
            {
                bool hasOpenInstances = Resources.FindObjectsOfTypeAll(typeof(T)).Any();
                if (hasOpenInstances)
                {
                    Close<T>();
                }
                else
                {
                    Open<T>();
                }
            }
            else if (typeof(ImGuiSceneView).IsAssignableFrom(typeof(T)))
            {
                ImGuiSceneViewManager.Toggle(typeof(T));
            }
            else
            {
                throw new InvalidOperationException($"Type {typeof(T)} is not a valid ImGuiEditorWindow or ImGuiSceneView");
            }
        }
    }
}