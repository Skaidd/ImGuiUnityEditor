using System.Linq;
using UnityEditor;
using UnityEngine;

namespace ImGuiUnityEditor
{
    /// <summary>
    /// Base class for creating custom ImGui editor windows in the Unity Editor.
    /// </summary>
    public abstract class ImGuiEditorWindow : EditorWindow, IImGuiObject
    {
        /// <summary>
        /// The name of the window
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// The tooltip for the window
        /// </summary>
        public virtual string Tooltip { get; set; }

        /// <summary>
        /// The minimum size of the window
        /// </summary>
        public virtual Vector2 MinSize { get; set; } = new Vector2(50f, 50f);

        /// <summary>
        /// The maximum size of the window
        /// </summary>
        public virtual Vector2 MaxSize { get; set; } = new Vector2(4000f, 4000f);

        /// <summary>
        /// The icon for the window
        /// </summary>
        public virtual Texture2D Icon { get; set; }

        /// <summary>
        /// The style for the ImGui object
        /// </summary>
        public ImGuiObjectStyle Style { get; set; } = new();

        private ImGuiRendererContainer _container;
        ImGuiRendererContainer IImGuiObject.Container => _container;

        protected void CreateGUI()
        {
            _container = new ImGuiRendererContainer();
            _container.OnStart += InitializeWindow;
            _container.BeforeDraw += () => Style.Begin();
            _container.OnDraw += Draw;
            _container.AfterDraw += () => Style.End();
            _container.OnEnd += End;
            rootVisualElement.Add(_container);
        }

        private void InitializeWindow()
        {
            wantsMouseMove = true;
            wantsMouseEnterLeaveWindow = true;

            var title = Name;
            if (string.IsNullOrEmpty(title))
            {
                if (GetType().GetCustomAttributes(typeof(ImGuiMenuAttribute), false)
                    .FirstOrDefault() is ImGuiMenuAttribute attribute)
                {
                    title = attribute.ItemName?.Split('/').LastOrDefault() ?? GetType().Name;
                }
                else
                {
                    title = GetType().Name;
                }
            }

            titleContent = new GUIContent(title)
            {
                tooltip = Tooltip,
                image = Icon
            };

            minSize = MinSize;
            maxSize = MaxSize;

            Start();
        }

        protected void OnGUI()
        {
            _container?.Draw();
            Repaint();
        }

        /// <summary>
        /// Sets the style for the ImGui object
        /// </summary>
        /// <typeparam name="T">The style to set</typeparam>
        public void SetStyle<T>() where T : ImGuiObjectStyle, new()
        {
            Style.Set<T>();
        }

        /// <summary>
        /// Called when the window is created
        /// </summary>
        public virtual void Start() { }

        /// <summary>
        /// Called on each ImGui frame when the window is open
        /// </summary>
        public abstract void Draw();

        /// <summary>
        /// Called when the window is closed
        /// </summary>
        public virtual void End() { }
    }
}

