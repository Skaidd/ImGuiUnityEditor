namespace ImGuiUnityEditor
{
    /// <summary>
    /// ImGui Object
    /// </summary>
    public interface IImGuiObject
    {
        /// <summary>
        /// The style for the ImGui object
        /// </summary>
        ImGuiObjectStyle Style { get; set; }

        /// <summary>
        /// Called when the ImGui object is created.
        /// </summary>
        void Start();

        /// <summary>
        /// Called when the ImGui object is drawn.
        /// </summary>
        void Draw();

        /// <summary>
        /// Called when the ImGui object is destroyed.
        /// </summary>
        void End();

        /// <summary>
        /// The container for the ImGui renderer
        /// </summary>
        internal ImGuiRendererContainer Container { get; }
    }
}

