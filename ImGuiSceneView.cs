
namespace ImGuiUnityEditor
{
    public abstract class ImGuiSceneView : IImGuiObject
    {
        /// <summary>
        /// The style for the ImGui object
        /// </summary>
        public ImGuiObjectStyle Style { get; set; } = new();

        private ImGuiRendererContainer _container;
        ImGuiRendererContainer IImGuiObject.Container => _container;

        /// <summary>
        /// Whether the ImGui Scene View is enabled
        /// </summary>
        [ImGuiSerializedField] internal bool IsEnabled = true;
        private bool _wasActive = false;

        /// <summary>
        /// Sets the container for this scene view element
        /// </summary>
        internal void SetContainer(ImGuiRendererContainer container)
        {
            _container = container;
            _container.OnStart += () => ImGuiUnityEditorData.instance.Load(this);
            _container.OnDraw += OnDraw;
            _container.OnEnd += () => ImGuiUnityEditorData.instance.Save(this);
        }

        private void OnDraw()
        {
            if (!IsEnabled) { return; }

            bool isCurrentlyActive = Active();

            // If activated and wasn't active before, call Start
            if (isCurrentlyActive && !_wasActive)
            {
                Start();
            }
            // If deactivated and was active before, call End
            else if (!isCurrentlyActive && _wasActive)
            {
                End();
            }

            _wasActive = isCurrentlyActive;

            if (!isCurrentlyActive) { return; }

            Style.Begin();
            Draw();
            Style.End();
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
        /// Whether this handler is active
        /// </summary>
        public virtual bool Active() => true;

        /// <summary>
        /// Called when this handler is first activated
        /// </summary>
        public virtual void Start() { }

        /// <summary>
        /// Called on each ImGui frame when this handler is active
        /// </summary>
        public abstract void Draw();

        /// <summary>
        /// Called when this handler is deactivated
        /// </summary>
        public virtual void End() { }
    }
}

