using UnityEngine;
using System;
using UnityEngine.UIElements;

namespace ImGuiUnityEditor
{
    /// <summary>
    /// Manages the rendering of ImGui objects in the Unity Editor.
    /// </summary>
    public class ImGuiRendererContainer : VisualElement
    {
        /// <summary>
        /// Action called when the ImGui renderer starts.
        /// </summary>
        public Action OnStart { get; set; }

        /// <summary>
        /// Action called before drawing.
        /// </summary>
        public Action BeforeDraw { get; set; }

        /// <summary>
        /// Action called when drawing.
        /// </summary>
        public Action OnDraw { get; set; }

        /// <summary>
        /// Action called after drawing.
        /// </summary>
        public Action AfterDraw { get; set; }

        /// <summary>
        /// Action called when the ImGui renderer ends.
        /// </summary>
        public Action OnEnd { get; set; }

        /// <summary>
        /// The ImGui renderer instance.
        /// </summary>
        private ImGuiRenderer _renderer;
        
        public ImGuiRendererContainer()
        {
            this.style.position = Position.Absolute;
            this.pickingMode = PickingMode.Ignore;
            this.focusable = false;
            this.StretchToParentSize();
            this.RegisterCallback<AttachToPanelEvent>(OnAttachToPanel);
            this.RegisterCallback<DetachFromPanelEvent>(OnDetachFromPanel);
        }

        private void OnAttachToPanel(AttachToPanelEvent evt)
        {
            _renderer = new ImGuiRenderer();
            _renderer.SetInputHandler<ImGuiEditorInputHandler>();

            if (UnityEditor.EditorGUIUtility.isProSkin)
                _renderer.SetStyle<ImGuiDarkStyle>();
            else
                _renderer.SetStyle<ImGuiLightStyle>();
            
            OnStart?.Invoke();
        }

        private void OnDetachFromPanel(DetachFromPanelEvent evt)
        {
            try
            {
                OnEnd?.Invoke();
            }
            catch (Exception e)
            {
                Debug.LogError($"Error during OnEnd: {e.Message}\n{e.StackTrace}");
            }
            finally
            {
                _renderer.Dispose();
                _renderer = null;
            }
        }

        /// <summary>
        /// Loads the settings from a string.
        /// </summary>
        /// <param name="iniData">The settings to load.</param>
        public void LoadSettings(string iniData)
        {
            _renderer?.LoadSettings(iniData);
        }

        /// <summary>
        /// Saves the settings to a string.
        /// </summary>
        /// <returns>The settings as a string.</returns>
        public string SaveSettings()
        {
            return _renderer?.SaveSettings();
        }

        /// <summary>
        /// Draws the ImGui objects.
        /// </summary>
        public void Draw()
        {
            if (style.display == DisplayStyle.None
            || _renderer == null
            || float.IsNaN(contentRect.size.x)
            || float.IsNaN(contentRect.size.y)) { return; }

            _renderer.Begin(new Vector2(contentRect.size.x, contentRect.size.y));
            BeforeDraw?.Invoke();
            OnDraw?.Invoke();
            AfterDraw?.Invoke();
            var renderTexture = _renderer.End();

            style.backgroundImage = Background.FromRenderTexture(renderTexture);
        }
    }
}
