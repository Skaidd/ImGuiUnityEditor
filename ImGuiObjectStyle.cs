using System;
using UnityEngine;

namespace ImGuiUnityEditor
{
    /// <summary>
    /// Dark theme
    /// </summary>
    public class ImGuiDarkStyle : ImGuiObjectStyle
    {
        public ImGuiDarkStyle()
        {
            Alpha = 1.0f;
            DisabledAlpha = 0.6f;
            WindowPadding = new Vector2(5.5f, 8.3f);
            WindowRounding = 4.5f;
            WindowBorderSize = 1.0f;
            WindowMinSize = new Vector2(32.0f, 32.0f);
            WindowTitleAlign = new Vector2(0.0f, 0.5f);
            ChildRounding = 3.2f;
            ChildBorderSize = 1.0f;
            PopupRounding = 2.7f;
            PopupBorderSize = 1.0f;
            FramePadding = new Vector2(4.0f, 3.0f);
            FrameRounding = 2.4f;
            FrameBorderSize = 0.0f;
            ItemSpacing = new Vector2(8.0f, 4.0f);
            ItemInnerSpacing = new Vector2(4.0f, 4.0f);
            CellPadding = new Vector2(4.0f, 2.0f);
            IndentSpacing = 21.0f;
            ScrollbarSize = 14.0f;
            ScrollbarRounding = 9.0f;
            GrabMinSize = 10.0f;
            GrabRounding = 3.2f;
            TabRounding = 3.5f;
            TabBorderSize = 1.0f;
            ButtonTextAlign = new Vector2(0.5f, 0.5f);
            SelectableTextAlign = new Vector2(0.0f, 0.0f);

            TextColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            TextDisabledColor = new Color(0.498f, 0.498f, 0.498f, 1.0f);
            WindowBgColor = new Color(0.059f, 0.059f, 0.059f, 0.94f);
            ChildBgColor = new Color(0.0f, 0.0f, 0.0f, 0.0f);
            PopupBgColor = new Color(0.078f, 0.078f, 0.078f, 0.94f);
            BorderColor = new Color(0.427f, 0.427f, 0.498f, 0.5f);
            BorderShadowColor = new Color(0.0f, 0.0f, 0.0f, 0.0f);
            FrameBgColor = new Color(0.137f, 0.173f, 0.227f, 0.54f);
            FrameBgHoveredColor = new Color(0.212f, 0.255f, 0.302f, 0.4f);
            FrameBgActiveColor = new Color(0.043f, 0.047f, 0.047f, 0.67f);
            TitleBgColor = new Color(0.039f, 0.039f, 0.039f, 1.0f);
            TitleBgActiveColor = new Color(0.078f, 0.082f, 0.09f, 1.0f);
            TitleBgCollapsedColor = new Color(0.0f, 0.0f, 0.0f, 0.51f);
            MenuBarBgColor = new Color(0.137f, 0.137f, 0.137f, 1.0f);
            ScrollbarBgColor = new Color(0.02f, 0.02f, 0.02f, 0.53f);
            ScrollbarGrabColor = new Color(0.31f, 0.31f, 0.31f, 1.0f);
            ScrollbarGrabHoveredColor = new Color(0.408f, 0.408f, 0.408f, 1.0f);
            ScrollbarGrabActiveColor = new Color(0.51f, 0.51f, 0.51f, 1.0f);
            CheckMarkColor = new Color(0.718f, 0.784f, 0.843f, 1.0f);
            SliderGrabColor = new Color(0.478f, 0.525f, 0.573f, 1.0f);
            SliderGrabActiveColor = new Color(0.29f, 0.318f, 0.353f, 1.0f);
            ButtonColor = new Color(0.149f, 0.161f, 0.176f, 0.4f);
            ButtonHoveredColor = new Color(0.137f, 0.145f, 0.157f, 1.0f);
            ButtonActiveColor = new Color(0.078f, 0.086f, 0.09f, 1.0f);
            HeaderColor = new Color(0.196f, 0.216f, 0.239f, 0.31f);
            HeaderHoveredColor = new Color(0.165f, 0.176f, 0.192f, 0.8f);
            HeaderActiveColor = new Color(0.075f, 0.082f, 0.09f, 1.0f);
            SeparatorColor = new Color(0.427f, 0.427f, 0.498f, 0.5f);
            SeparatorHoveredColor = new Color(0.239f, 0.325f, 0.424f, 0.78f);
            SeparatorActiveColor = new Color(0.275f, 0.38f, 0.498f, 1.0f);
            ResizeGripColor = new Color(0.29f, 0.329f, 0.376f, 0.2f);
            ResizeGripHoveredColor = new Color(0.239f, 0.298f, 0.369f, 0.67f);
            ResizeGripActiveColor = new Color(0.165f, 0.176f, 0.188f, 0.95f);
            TabColor = new Color(0.118f, 0.125f, 0.133f, 0.862f);
            TabHoveredColor = new Color(0.329f, 0.408f, 0.502f, 0.8f);
            TabActiveColor = new Color(0.243f, 0.247f, 0.255f, 1.0f);
            TabSelectedColor = new Color(0.243f, 0.247f, 0.255f, 1.0f);
            TabSelectedOverlineColor = new Color(0.243f, 0.247f, 0.255f, 1.0f);
            TabDimmedColor = new Color(0.067f, 0.102f, 0.145f, 0.972f);
            TabDimmedSelectedColor = new Color(0.133f, 0.259f, 0.424f, 1.0f);
            TabDimmedSelectedOverlineColor = new Color(0.133f, 0.259f, 0.424f, 1.0f);
            DockingPreviewColor = new Color(0.259f, 0.588f, 0.976f, 0.7f);
            DockingEmptyBgColor = new Color(0.2f, 0.2f, 0.2f, 1.0f);
            PlotLinesColor = new Color(0.608f, 0.608f, 0.608f, 1.0f);
            PlotLinesHoveredColor = new Color(1.0f, 0.427f, 0.349f, 1.0f);
            PlotHistogramColor = new Color(0.898f, 0.698f, 0.0f, 1.0f);
            PlotHistogramHoveredColor = new Color(1.0f, 0.6f, 0.0f, 1.0f);
            TableHeaderBgColor = new Color(0.188f, 0.188f, 0.2f, 1.0f);
            TableBorderStrongColor = new Color(0.31f, 0.31f, 0.349f, 1.0f);
            TableBorderLightColor = new Color(0.227f, 0.227f, 0.247f, 1.0f);
            TableRowBgColor = new Color(0.0f, 0.0f, 0.0f, 0.0f);
            TableRowBgAltColor = new Color(1.0f, 1.0f, 1.0f, 0.06f);
            TextLinkColor = new Color(0.259f, 0.588f, 0.976f, 1.0f);
            TextSelectedBgColor = new Color(0.259f, 0.588f, 0.976f, 0.35f);
            DragDropTargetColor = new Color(1.0f, 1.0f, 0.0f, 0.9f);
            NavCursorColor = new Color(0.259f, 0.588f, 0.976f, 1.0f);
            NavWindowingHighlightColor = new Color(1.0f, 1.0f, 1.0f, 0.7f);
            NavWindowingDimBgColor = new Color(0.8f, 0.8f, 0.8f, 0.2f);
            ModalWindowDimBgColor = new Color(0.8f, 0.8f, 0.8f, 0.35f);
        }
    }

     /// <summary>
    /// Light theme
    /// </summary>
    public class ImGuiLightStyle : ImGuiObjectStyle
    {
        public ImGuiLightStyle()
        {
            Alpha = 1.0f;
            DisabledAlpha = 0.6f;
            WindowPadding = new Vector2(5.5f, 8.3f);
            WindowRounding = 4.5f;
            WindowBorderSize = 1.0f;
            WindowMinSize = new Vector2(32.0f, 32.0f);
            WindowTitleAlign = new Vector2(0.0f, 0.5f);
            ChildRounding = 3.2f;
            ChildBorderSize = 1.0f;
            PopupRounding = 2.7f;
            PopupBorderSize = 1.0f;
            FramePadding = new Vector2(4.0f, 3.0f);
            FrameRounding = 2.4f;
            FrameBorderSize = 1.0f;
            ItemSpacing = new Vector2(8.0f, 4.0f);
            ItemInnerSpacing = new Vector2(4.0f, 4.0f);
            CellPadding = new Vector2(4.0f, 2.0f);
            IndentSpacing = 21.0f;
            ScrollbarSize = 14.0f;
            ScrollbarRounding = 9.0f;
            GrabMinSize = 10.0f;
            GrabRounding = 3.2f;
            TabRounding = 3.5f;
            TabBorderSize = 1.0f;
            ButtonTextAlign = new Vector2(0.5f, 0.5f);
            SelectableTextAlign = new Vector2(0.0f, 0.0f);

            TextColor = new Color(0.00f, 0.00f, 0.00f, 1.00f);
            TextDisabledColor = new Color(0.50f, 0.50f, 0.50f, 1.00f);
            WindowBgColor = new Color(0.94f, 0.94f, 0.94f, 0.98f);
            ChildBgColor = new Color(0.00f, 0.00f, 0.00f, 0.00f);
            PopupBgColor = new Color(0.98f, 0.98f, 0.98f, 0.98f);
            BorderColor = new Color(0.43f, 0.43f, 0.50f, 0.50f);
            BorderShadowColor = new Color(0.00f, 0.00f, 0.00f, 0.00f);
            FrameBgColor = new Color(0.91f, 0.91f, 0.91f, 1.00f);
            FrameBgHoveredColor = new Color(0.78f, 0.82f, 0.88f, 0.40f);
            FrameBgActiveColor = new Color(0.65f, 0.75f, 0.85f, 0.67f);
            TitleBgColor = new Color(0.86f, 0.86f, 0.86f, 1.00f);
            TitleBgActiveColor = new Color(0.78f, 0.78f, 0.78f, 1.00f);
            TitleBgCollapsedColor = new Color(0.98f, 0.98f, 0.98f, 0.51f);
            MenuBarBgColor = new Color(0.86f, 0.86f, 0.86f, 1.00f);
            ScrollbarBgColor = new Color(0.98f, 0.98f, 0.98f, 0.53f);
            ScrollbarGrabColor = new Color(0.69f, 0.69f, 0.69f, 1.00f);
            ScrollbarGrabHoveredColor = new Color(0.59f, 0.59f, 0.59f, 1.00f);
            ScrollbarGrabActiveColor = new Color(0.49f, 0.49f, 0.49f, 1.00f);
            CheckMarkColor = new Color(0.26f, 0.40f, 0.56f, 1.00f);
            SliderGrabColor = new Color(0.24f, 0.35f, 0.50f, 0.78f);
            SliderGrabActiveColor = new Color(0.26f, 0.32f, 0.40f, 0.60f);
            ButtonColor = new Color(0.85f, 0.85f, 0.85f, 0.40f);
            ButtonHoveredColor = new Color(0.78f, 0.82f, 0.88f, 1.00f);
            ButtonActiveColor = new Color(0.65f, 0.75f, 0.85f, 1.00f);
            HeaderColor = new Color(0.78f, 0.82f, 0.88f, 0.31f);
            HeaderHoveredColor = new Color(0.78f, 0.82f, 0.88f, 0.80f);
            HeaderActiveColor = new Color(0.65f, 0.75f, 0.85f, 1.00f);
            SeparatorColor = new Color(0.43f, 0.43f, 0.50f, 0.50f);
            SeparatorHoveredColor = new Color(0.24f, 0.33f, 0.42f, 0.78f);
            SeparatorActiveColor = new Color(0.28f, 0.38f, 0.50f, 1.00f);
            ResizeGripColor = new Color(0.35f, 0.35f, 0.35f, 0.17f);
            ResizeGripHoveredColor = new Color(0.24f, 0.33f, 0.42f, 0.67f);
            ResizeGripActiveColor = new Color(0.28f, 0.38f, 0.50f, 0.95f);
            TabColor = new Color(0.76f, 0.80f, 0.84f, 0.93f);
            TabHoveredColor = new Color(0.24f, 0.33f, 0.42f, 0.80f);
            TabActiveColor = new Color(0.60f, 0.73f, 0.88f, 1.00f);
            TabSelectedColor = new Color(0.24f, 0.33f, 0.42f, 1.00f);
            TabSelectedOverlineColor = new Color(0.24f, 0.33f, 0.42f, 1.00f);
            TabDimmedColor = new Color(0.76f, 0.80f, 0.84f, 0.20f);
            TabDimmedSelectedColor = new Color(0.24f, 0.33f, 0.42f, 0.40f);
            TabDimmedSelectedOverlineColor = new Color(0.24f, 0.33f, 0.42f, 0.40f);
            DockingPreviewColor = new Color(0.24f, 0.33f, 0.42f, 0.70f);
            DockingEmptyBgColor = new Color(0.80f, 0.80f, 0.80f, 1.00f);
            PlotLinesColor = new Color(0.39f, 0.39f, 0.39f, 1.00f);
            PlotLinesHoveredColor = new Color(1.00f, 0.43f, 0.35f, 1.00f);
            PlotHistogramColor = new Color(0.90f, 0.70f, 0.00f, 1.00f);
            PlotHistogramHoveredColor = new Color(1.00f, 0.60f, 0.00f, 1.00f);
            TableHeaderBgColor = new Color(0.78f, 0.82f, 0.88f, 1.00f);
            TableBorderStrongColor = new Color(0.57f, 0.57f, 0.64f, 1.00f);
            TableBorderLightColor = new Color(0.68f, 0.68f, 0.74f, 1.00f);
            TableRowBgColor = new Color(0.00f, 0.00f, 0.00f, 0.00f);
            TableRowBgAltColor = new Color(0.30f, 0.30f, 0.30f, 0.09f);
            TextLinkColor = new Color(0.24f, 0.33f, 0.42f, 1.00f);
            TextSelectedBgColor = new Color(0.24f, 0.33f, 0.42f, 0.35f);
            DragDropTargetColor = new Color(0.24f, 0.33f, 0.42f, 0.95f);
            NavCursorColor = new Color(0.24f, 0.33f, 0.42f, 0.80f);
            NavWindowingHighlightColor = new Color(0.70f, 0.70f, 0.70f, 0.70f);
            NavWindowingDimBgColor = new Color(0.20f, 0.20f, 0.20f, 0.20f);
            ModalWindowDimBgColor = new Color(0.20f, 0.20f, 0.20f, 0.35f);
        }
    }

    /// <summary>
    /// Style settings for ImGui objects
    /// </summary>
    [Serializable]
    public class ImGuiObjectStyle
    {
        private int _styleVarCount = 0;
        private int _styleColorCount = 0;

        [field: SerializeField] public string FontName { get; set; } = "ProggyClean";
        [field: SerializeField] public float Alpha { get; set; } = 1.0f;
        [field: SerializeField] public float DisabledAlpha { get; set; } = 0.6f;
        [field: SerializeField] public Vector2 WindowPadding { get; set; } = new Vector2(8, 8);
        [field: SerializeField] public float WindowRounding { get; set; } = 0.0f;
        [field: SerializeField] public float WindowBorderSize { get; set; } = 1.0f;
        [field: SerializeField] public Vector2 WindowMinSize { get; set; } = new Vector2(32, 32);
        [field: SerializeField] public Vector2 WindowTitleAlign { get; set; } = new Vector2(0, 0.5f);
        [field: SerializeField] public float ChildRounding { get; set; } = 0.0f;
        [field: SerializeField] public float ChildBorderSize { get; set; } = 1.0f;
        [field: SerializeField] public float PopupRounding { get; set; } = 0.0f;
        [field: SerializeField] public float PopupBorderSize { get; set; } = 1.0f;
        [field: SerializeField] public Vector2 FramePadding { get; set; } = new Vector2(4, 3);
        [field: SerializeField] public float FrameRounding { get; set; } = 0.0f;
        [field: SerializeField] public float FrameBorderSize { get; set; } = 0.0f;
        [field: SerializeField] public Vector2 ItemSpacing { get; set; } = new Vector2(8, 4);
        [field: SerializeField] public Vector2 ItemInnerSpacing { get; set; } = new Vector2(4, 4);
        [field: SerializeField] public float IndentSpacing { get; set; } = 21.0f;
        [field: SerializeField] public Vector2 CellPadding { get; set; } = new Vector2(4, 2);
        [field: SerializeField] public float ScrollbarSize { get; set; } = 14.0f;
        [field: SerializeField] public float ScrollbarRounding { get; set; } = 9.0f;
        [field: SerializeField] public float GrabMinSize { get; set; } = 10.0f;
        [field: SerializeField] public float GrabRounding { get; set; } = 0.0f;
        [field: SerializeField] public float TabRounding { get; set; } = 4.0f;
        [field: SerializeField] public float TabBorderSize { get; set; } = 0.0f;
        [field: SerializeField] public float TabBarBorderSize { get; set; } = 1.0f;
        [field: SerializeField] public float TabBarOverlineSize { get; set; } = 1.0f;
        [field: SerializeField] public float TableAngledHeadersAngle { get; set; } = 35.0f;
        [field: SerializeField] public Vector2 TableAngledHeadersTextAlign { get; set; } = new Vector2(1.0f, 0.5f);
        [field: SerializeField] public Vector2 ButtonTextAlign { get; set; } = new Vector2(0.5f, 0.5f);
        [field: SerializeField] public Vector2 SelectableTextAlign { get; set; } = new Vector2(0.0f, 0.0f);
        [field: SerializeField] public float SeparatorTextBorderSize { get; set; } = 3.0f;
        [field: SerializeField] public Vector2 SeparatorTextAlign { get; set; } = new Vector2(0.0f, 0.5f);
        [field: SerializeField] public Vector2 SeparatorTextPadding { get; set; } = new Vector2(20, 3);
        [field: SerializeField] public float DockingSeparatorSize { get; set; } = 2.0f;

        [field: SerializeField] public Color TextColor { get; set; } = new Color(0.898f, 0.898f, 0.898f, 1.0f);
        [field: SerializeField] public Color TextDisabledColor { get; set; } = new Color(0.6f, 0.6f, 0.6f, 1.0f);
        [field: SerializeField] public Color WindowBgColor { get; set; } = new Color(0.0f, 0.0f, 0.0f, 0.85f);
        [field: SerializeField] public Color ChildBgColor { get; set; } = new Color(0.0f, 0.0f, 0.0f, 0.0f);
        [field: SerializeField] public Color PopupBgColor { get; set; } = new Color(0.11f, 0.11f, 0.137f, 0.92f);
        [field: SerializeField] public Color BorderColor { get; set; } = new Color(0.498f, 0.498f, 0.498f, 0.5f);
        [field: SerializeField] public Color BorderShadowColor { get; set; } = new Color(0.0f, 0.0f, 0.0f, 0.0f);
        [field: SerializeField] public Color FrameBgColor { get; set; } = new Color(0.427f, 0.427f, 0.427f, 0.39f);
        [field: SerializeField] public Color FrameBgHoveredColor { get; set; } = new Color(0.467f, 0.467f, 0.686f, 0.4f);
        [field: SerializeField] public Color FrameBgActiveColor { get; set; } = new Color(0.42f, 0.408f, 0.639f, 0.69f);
        [field: SerializeField] public Color TitleBgColor { get; set; } = new Color(0.267f, 0.267f, 0.537f, 0.83f);
        [field: SerializeField] public Color TitleBgActiveColor { get; set; } = new Color(0.318f, 0.318f, 0.627f, 0.87f);
        [field: SerializeField] public Color TitleBgCollapsedColor { get; set; } = new Color(0.4f, 0.4f, 0.8f, 0.2f);
        [field: SerializeField] public Color MenuBarBgColor { get; set; } = new Color(0.4f, 0.4f, 0.549f, 0.8f);
        [field: SerializeField] public Color ScrollbarBgColor { get; set; } = new Color(0.2f, 0.247f, 0.298f, 0.6f);
        [field: SerializeField] public Color ScrollbarGrabColor { get; set; } = new Color(0.4f, 0.4f, 0.8f, 0.3f);
        [field: SerializeField] public Color ScrollbarGrabHoveredColor { get; set; } = new Color(0.4f, 0.4f, 0.8f, 0.4f);
        [field: SerializeField] public Color ScrollbarGrabActiveColor { get; set; } = new Color(0.408f, 0.388f, 0.8f, 0.6f);
        [field: SerializeField] public Color CheckMarkColor { get; set; } = new Color(0.26f, 0.59f, 0.98f, 1.0f);
        [field: SerializeField] public Color SliderGrabColor { get; set; } = new Color(0.24f, 0.52f, 0.88f, 1.0f);
        [field: SerializeField] public Color SliderGrabActiveColor { get; set; } = new Color(0.26f, 0.59f, 0.98f, 1.0f);
        [field: SerializeField] public Color ButtonColor { get; set; } = new Color(0.349f, 0.4f, 0.608f, 0.62f);
        [field: SerializeField] public Color ButtonHoveredColor { get; set; } = new Color(0.4f, 0.478f, 0.71f, 0.79f);
        [field: SerializeField] public Color ButtonActiveColor { get; set; } = new Color(0.459f, 0.537f, 0.8f, 1.0f);
        [field: SerializeField] public Color HeaderColor { get; set; } = new Color(0.4f, 0.4f, 0.898f, 0.45f);
        [field: SerializeField] public Color HeaderHoveredColor { get; set; } = new Color(0.447f, 0.447f, 0.898f, 0.8f);
        [field: SerializeField] public Color HeaderActiveColor { get; set; } = new Color(0.529f, 0.529f, 0.867f, 0.8f);
        [field: SerializeField] public Color SeparatorColor { get; set; } = new Color(0.498f, 0.498f, 0.498f, 0.6f);
        [field: SerializeField] public Color SeparatorHoveredColor { get; set; } = new Color(0.6f, 0.6f, 0.698f, 1.0f);
        [field: SerializeField] public Color SeparatorActiveColor { get; set; } = new Color(0.698f, 0.698f, 0.898f, 1.0f);
        [field: SerializeField] public Color ResizeGripColor { get; set; } = new Color(1.0f, 1.0f, 1.0f, 0.1f);
        [field: SerializeField] public Color ResizeGripHoveredColor { get; set; } = new Color(0.776f, 0.82f, 1.0f, 0.6f);
        [field: SerializeField] public Color ResizeGripActiveColor { get; set; } = new Color(0.776f, 0.82f, 1.0f, 0.9f);
        [field: SerializeField] public Color TabColor { get; set; } = new Color(0.333f, 0.333f, 0.682f, 0.786f);
        [field: SerializeField] public Color TabHoveredColor { get; set; } = new Color(0.447f, 0.447f, 0.898f, 0.8f);
        [field: SerializeField] public Color TabActiveColor { get; set; } = new Color(0.404f, 0.404f, 0.725f, 0.842f);
        [field: SerializeField] public Color TabSelectedColor { get; set; } = new Color(0.404f, 0.404f, 0.725f, 0.842f);
        [field: SerializeField] public Color TabSelectedOverlineColor { get; set; } = new Color(0.404f, 0.404f, 0.725f, 0.842f);
        [field: SerializeField] public Color TabDimmedColor { get; set; } = new Color(0.282f, 0.282f, 0.569f, 0.821f);
        [field: SerializeField] public Color TabDimmedSelectedColor { get; set; } = new Color(0.349f, 0.349f, 0.651f, 0.837f);
        [field: SerializeField] public Color TabDimmedSelectedOverlineColor { get; set; } = new Color(0.349f, 0.349f, 0.651f, 0.837f);
        [field: SerializeField] public Color DockingPreviewColor { get; set; } = new Color(0.447f, 0.447f, 0.898f, 0.8f);
        [field: SerializeField] public Color DockingEmptyBgColor { get; set; } = new Color(0.2f, 0.2f, 0.2f, 1.0f);
        [field: SerializeField] public Color PlotLinesColor { get; set; } = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        [field: SerializeField] public Color PlotLinesHoveredColor { get; set; } = new Color(0.898f, 0.698f, 0.0f, 1.0f);
        [field: SerializeField] public Color PlotHistogramColor { get; set; } = new Color(0.898f, 0.698f, 0.0f, 1.0f);
        [field: SerializeField] public Color PlotHistogramHoveredColor { get; set; } = new Color(1.0f, 0.6f, 0.0f, 1.0f);
        [field: SerializeField] public Color TableHeaderBgColor { get; set; } = new Color(0.267f, 0.267f, 0.376f, 1.0f);
        [field: SerializeField] public Color TableBorderStrongColor { get; set; } = new Color(0.31f, 0.31f, 0.447f, 1.0f);
        [field: SerializeField] public Color TableBorderLightColor { get; set; } = new Color(0.259f, 0.259f, 0.278f, 1.0f);
        [field: SerializeField] public Color TableRowBgColor { get; set; } = new Color(0.0f, 0.0f, 0.0f, 0.0f);
        [field: SerializeField] public Color TableRowBgAltColor { get; set; } = new Color(1.0f, 1.0f, 1.0f, 0.07f);
        [field: SerializeField] public Color TextLinkColor { get; set; } = new Color(0.447f, 0.447f, 0.898f, 0.8f);
        [field: SerializeField] public Color TextSelectedBgColor { get; set; } = new Color(0.0f, 0.0f, 1.0f, 0.35f);
        [field: SerializeField] public Color DragDropTargetColor { get; set; } = new Color(1.0f, 1.0f, 0.0f, 0.9f);
        [field: SerializeField] public Color NavCursorColor { get; set; } = new Color(0.447f, 0.447f, 0.898f, 0.8f);
        [field: SerializeField] public Color NavWindowingHighlightColor { get; set; } = new Color(1.0f, 1.0f, 1.0f, 0.7f);
        [field: SerializeField] public Color NavWindowingDimBgColor { get; set; } = new Color(0.8f, 0.8f, 0.8f, 0.2f);
        [field: SerializeField] public Color ModalWindowDimBgColor { get; set; } = new Color(0.2f, 0.2f, 0.2f, 0.35f);

        private void PushFont(string fontName)
        {
            var font = ImGui.GetIO().Fonts.GetFont(fontName);
            ImGui.PushFont(font);
        }

        private void PushStyleVar(ImGuiStyleVar styleVar, float value)
        {
            ImGui.PushStyleVar(styleVar, value);
            _styleVarCount++;
        }

        private void PushStyleVar(ImGuiStyleVar styleVar, Vector2 value)
        {
            ImGui.PushStyleVar(styleVar, new Vector2(value.x, value.y));
            _styleVarCount++;
        }

        private void PushStyleColor(ImGuiCol colorId, Color color)
        {
            ImGui.PushStyleColor(colorId, new Vector4(color.r, color.g, color.b, color.a));
            _styleColorCount++;
        }

        /// <summary>
        /// Sets the style to the given type.
        /// </summary>
        /// <typeparam name="T">The type of the style to set.</typeparam>
        public void Set<T>() where T : ImGuiObjectStyle, new()
        {
            T style = new();

            this.FontName = style.FontName;
            this.Alpha = style.Alpha;
            this.DisabledAlpha = style.DisabledAlpha;
            this.WindowPadding = style.WindowPadding;
            this.WindowRounding = style.WindowRounding;
            this.WindowBorderSize = style.WindowBorderSize;
            this.WindowMinSize = style.WindowMinSize;
            this.WindowTitleAlign = style.WindowTitleAlign;
            this.ChildRounding = style.ChildRounding;
            this.ChildBorderSize = style.ChildBorderSize;
            this.PopupRounding = style.PopupRounding;
            this.PopupBorderSize = style.PopupBorderSize;
            this.FramePadding = style.FramePadding;
            this.FrameRounding = style.FrameRounding;
            this.FrameBorderSize = style.FrameBorderSize;
            this.ItemSpacing = style.ItemSpacing;
            this.ItemInnerSpacing = style.ItemInnerSpacing;
            this.IndentSpacing = style.IndentSpacing;
            this.CellPadding = style.CellPadding;
            this.ScrollbarSize = style.ScrollbarSize;
            this.ScrollbarRounding = style.ScrollbarRounding;
            this.GrabMinSize = style.GrabMinSize;
            this.GrabRounding = style.GrabRounding;
            this.TabRounding = style.TabRounding;
            this.TabBorderSize = style.TabBorderSize;
            this.TabBarBorderSize = style.TabBarBorderSize;
            this.TabBarOverlineSize = style.TabBarOverlineSize;
            this.TableAngledHeadersAngle = style.TableAngledHeadersAngle;
            this.TableAngledHeadersTextAlign = style.TableAngledHeadersTextAlign;
            this.ButtonTextAlign = style.ButtonTextAlign;
            this.SelectableTextAlign = style.SelectableTextAlign;
            this.SeparatorTextBorderSize = style.SeparatorTextBorderSize;
            this.SeparatorTextAlign = style.SeparatorTextAlign;
            this.SeparatorTextPadding = style.SeparatorTextPadding;
            this.DockingSeparatorSize = style.DockingSeparatorSize;
            this.TextColor = style.TextColor;
            this.TextDisabledColor = style.TextDisabledColor;
            this.WindowBgColor = style.WindowBgColor;
            this.ChildBgColor = style.ChildBgColor;
            this.PopupBgColor = style.PopupBgColor;
            this.BorderColor = style.BorderColor;
            this.BorderShadowColor = style.BorderShadowColor;
            this.FrameBgColor = style.FrameBgColor;
            this.FrameBgHoveredColor = style.FrameBgHoveredColor;
            this.FrameBgActiveColor = style.FrameBgActiveColor;
            this.TitleBgColor = style.TitleBgColor;
            this.TitleBgActiveColor = style.TitleBgActiveColor;
            this.TitleBgCollapsedColor = style.TitleBgCollapsedColor;
            this.MenuBarBgColor = style.MenuBarBgColor;
            this.ScrollbarBgColor = style.ScrollbarBgColor;
            this.ScrollbarGrabColor = style.ScrollbarGrabColor;
            this.ScrollbarGrabHoveredColor = style.ScrollbarGrabHoveredColor;
            this.ScrollbarGrabActiveColor = style.ScrollbarGrabActiveColor;
            this.CheckMarkColor = style.CheckMarkColor;
            this.SliderGrabColor = style.SliderGrabColor;
            this.SliderGrabActiveColor = style.SliderGrabActiveColor;
            this.ButtonColor = style.ButtonColor;
            this.ButtonHoveredColor = style.ButtonHoveredColor;
            this.ButtonActiveColor = style.ButtonActiveColor;
            this.HeaderColor = style.HeaderColor;
            this.HeaderHoveredColor = style.HeaderHoveredColor;
            this.HeaderActiveColor = style.HeaderActiveColor;
            this.SeparatorColor = style.SeparatorColor;
            this.SeparatorHoveredColor = style.SeparatorHoveredColor;
            this.SeparatorActiveColor = style.SeparatorActiveColor;
            this.ResizeGripColor = style.ResizeGripColor;
            this.ResizeGripHoveredColor = style.ResizeGripHoveredColor;
            this.ResizeGripActiveColor = style.ResizeGripActiveColor;
            this.TabColor = style.TabColor;
            this.TabHoveredColor = style.TabHoveredColor;
            this.TabSelectedColor = style.TabSelectedColor;
            this.TabSelectedOverlineColor = style.TabSelectedOverlineColor;
            this.TabDimmedColor = style.TabDimmedColor;
            this.TabDimmedSelectedColor = style.TabDimmedSelectedColor;
            this.TabDimmedSelectedOverlineColor = style.TabDimmedSelectedOverlineColor;
            this.DockingPreviewColor = style.DockingPreviewColor;
            this.DockingEmptyBgColor = style.DockingEmptyBgColor;
            this.PlotLinesColor = style.PlotLinesColor;
            this.PlotLinesHoveredColor = style.PlotLinesHoveredColor;
            this.PlotHistogramColor = style.PlotHistogramColor;
            this.PlotHistogramHoveredColor = style.PlotHistogramHoveredColor;
            this.TableHeaderBgColor = style.TableHeaderBgColor;
            this.TableBorderStrongColor = style.TableBorderStrongColor;
            this.TableBorderLightColor = style.TableBorderLightColor;
            this.TableRowBgColor = style.TableRowBgColor;
            this.TableRowBgAltColor = style.TableRowBgAltColor;
            this.TextLinkColor = style.TextLinkColor;
            this.TextSelectedBgColor = style.TextSelectedBgColor;
            this.DragDropTargetColor = style.DragDropTargetColor;
            this.NavCursorColor = style.NavCursorColor;
            this.NavWindowingHighlightColor = style.NavWindowingHighlightColor;
            this.NavWindowingDimBgColor = style.NavWindowingDimBgColor;
            this.ModalWindowDimBgColor = style.ModalWindowDimBgColor;
        }

        public void Begin()
        {
            //* Push font    
            PushFont(FontName);

            //* Push variables
            PushStyleVar(ImGuiStyleVar.Alpha, Alpha);
            PushStyleVar(ImGuiStyleVar.DisabledAlpha, DisabledAlpha);
            PushStyleVar(ImGuiStyleVar.WindowPadding, WindowPadding);
            PushStyleVar(ImGuiStyleVar.WindowRounding, WindowRounding);
            PushStyleVar(ImGuiStyleVar.WindowBorderSize, WindowBorderSize);
            PushStyleVar(ImGuiStyleVar.WindowMinSize, WindowMinSize);
            PushStyleVar(ImGuiStyleVar.WindowTitleAlign, WindowTitleAlign);
            PushStyleVar(ImGuiStyleVar.ChildRounding, ChildRounding);
            PushStyleVar(ImGuiStyleVar.ChildBorderSize, ChildBorderSize);
            PushStyleVar(ImGuiStyleVar.PopupRounding, PopupRounding);
            PushStyleVar(ImGuiStyleVar.PopupBorderSize, PopupBorderSize);
            PushStyleVar(ImGuiStyleVar.FramePadding, FramePadding);
            PushStyleVar(ImGuiStyleVar.FrameRounding, FrameRounding);
            PushStyleVar(ImGuiStyleVar.FrameBorderSize, FrameBorderSize);
            PushStyleVar(ImGuiStyleVar.ItemSpacing, ItemSpacing);
            PushStyleVar(ImGuiStyleVar.ItemInnerSpacing, ItemInnerSpacing);
            PushStyleVar(ImGuiStyleVar.IndentSpacing, IndentSpacing);
            PushStyleVar(ImGuiStyleVar.CellPadding, CellPadding);
            PushStyleVar(ImGuiStyleVar.ScrollbarSize, ScrollbarSize);
            PushStyleVar(ImGuiStyleVar.ScrollbarRounding, ScrollbarRounding);
            PushStyleVar(ImGuiStyleVar.GrabMinSize, GrabMinSize);
            PushStyleVar(ImGuiStyleVar.GrabRounding, GrabRounding);
            PushStyleVar(ImGuiStyleVar.TabRounding, TabRounding);
            PushStyleVar(ImGuiStyleVar.TabBorderSize, TabBorderSize);
            PushStyleVar(ImGuiStyleVar.TabBarBorderSize, TabBarBorderSize);
            PushStyleVar(ImGuiStyleVar.TabBarOverlineSize, TabBarOverlineSize);
            PushStyleVar(ImGuiStyleVar.TableAngledHeadersAngle, TableAngledHeadersAngle);
            PushStyleVar(ImGuiStyleVar.TableAngledHeadersTextAlign, TableAngledHeadersTextAlign);
            PushStyleVar(ImGuiStyleVar.ButtonTextAlign, ButtonTextAlign);
            PushStyleVar(ImGuiStyleVar.SelectableTextAlign, SelectableTextAlign);
            PushStyleVar(ImGuiStyleVar.SeparatorTextBorderSize, SeparatorTextBorderSize);
            PushStyleVar(ImGuiStyleVar.SeparatorTextAlign, SeparatorTextAlign);
            PushStyleVar(ImGuiStyleVar.SeparatorTextPadding, SeparatorTextPadding);
            PushStyleVar(ImGuiStyleVar.DockingSeparatorSize, DockingSeparatorSize);

            //* Push colors
            PushStyleColor(ImGuiCol.Text, TextColor);
            PushStyleColor(ImGuiCol.TextDisabled, TextDisabledColor);
            PushStyleColor(ImGuiCol.WindowBg, WindowBgColor);
            PushStyleColor(ImGuiCol.ChildBg, ChildBgColor);
            PushStyleColor(ImGuiCol.PopupBg, PopupBgColor);
            PushStyleColor(ImGuiCol.Border, BorderColor);
            PushStyleColor(ImGuiCol.BorderShadow, BorderShadowColor);
            PushStyleColor(ImGuiCol.FrameBg, FrameBgColor);
            PushStyleColor(ImGuiCol.FrameBgHovered, FrameBgHoveredColor);
            PushStyleColor(ImGuiCol.FrameBgActive, FrameBgActiveColor);
            PushStyleColor(ImGuiCol.TitleBg, TitleBgColor);
            PushStyleColor(ImGuiCol.TitleBgActive, TitleBgActiveColor);
            PushStyleColor(ImGuiCol.TitleBgCollapsed, TitleBgCollapsedColor);
            PushStyleColor(ImGuiCol.MenuBarBg, MenuBarBgColor);
            PushStyleColor(ImGuiCol.ScrollbarBg, ScrollbarBgColor);
            PushStyleColor(ImGuiCol.ScrollbarGrab, ScrollbarGrabColor);
            PushStyleColor(ImGuiCol.ScrollbarGrabHovered, ScrollbarGrabHoveredColor);
            PushStyleColor(ImGuiCol.ScrollbarGrabActive, ScrollbarGrabActiveColor);
            PushStyleColor(ImGuiCol.CheckMark, CheckMarkColor);
            PushStyleColor(ImGuiCol.SliderGrab, SliderGrabColor);
            PushStyleColor(ImGuiCol.SliderGrabActive, SliderGrabActiveColor);
            PushStyleColor(ImGuiCol.Button, ButtonColor);
            PushStyleColor(ImGuiCol.ButtonHovered, ButtonHoveredColor);
            PushStyleColor(ImGuiCol.ButtonActive, ButtonActiveColor);
            PushStyleColor(ImGuiCol.Header, HeaderColor);
            PushStyleColor(ImGuiCol.HeaderHovered, HeaderHoveredColor);
            PushStyleColor(ImGuiCol.HeaderActive, HeaderActiveColor);
            PushStyleColor(ImGuiCol.Separator, SeparatorColor);
            PushStyleColor(ImGuiCol.SeparatorHovered, SeparatorHoveredColor);
            PushStyleColor(ImGuiCol.SeparatorActive, SeparatorActiveColor);
            PushStyleColor(ImGuiCol.ResizeGrip, ResizeGripColor);
            PushStyleColor(ImGuiCol.ResizeGripHovered, ResizeGripHoveredColor);
            PushStyleColor(ImGuiCol.ResizeGripActive, ResizeGripActiveColor);
            PushStyleColor(ImGuiCol.Tab, TabColor);
            PushStyleColor(ImGuiCol.TabHovered, TabHoveredColor);
            PushStyleColor(ImGuiCol.TabSelected, TabSelectedColor);
            PushStyleColor(ImGuiCol.TabSelectedOverline, TabSelectedOverlineColor);
            PushStyleColor(ImGuiCol.TabDimmed, TabDimmedColor);
            PushStyleColor(ImGuiCol.TabDimmedSelected, TabDimmedSelectedColor);
            PushStyleColor(ImGuiCol.TabDimmedSelectedOverline, TabDimmedSelectedOverlineColor);
            PushStyleColor(ImGuiCol.DockingPreview, DockingPreviewColor);
            PushStyleColor(ImGuiCol.DockingEmptyBg, DockingEmptyBgColor);
            PushStyleColor(ImGuiCol.PlotLines, PlotLinesColor);
            PushStyleColor(ImGuiCol.PlotLinesHovered, PlotLinesHoveredColor);
            PushStyleColor(ImGuiCol.PlotHistogram, PlotHistogramColor);
            PushStyleColor(ImGuiCol.PlotHistogramHovered, PlotHistogramHoveredColor);
            PushStyleColor(ImGuiCol.TableHeaderBg, TableHeaderBgColor);
            PushStyleColor(ImGuiCol.TableBorderStrong, TableBorderStrongColor);
            PushStyleColor(ImGuiCol.TableBorderLight, TableBorderLightColor);
            PushStyleColor(ImGuiCol.TableRowBg, TableRowBgColor);
            PushStyleColor(ImGuiCol.TableRowBgAlt, TableRowBgAltColor);
            PushStyleColor(ImGuiCol.TextLink, TextLinkColor);
            PushStyleColor(ImGuiCol.TextSelectedBg, TextSelectedBgColor);
            PushStyleColor(ImGuiCol.DragDropTarget, DragDropTargetColor);
            PushStyleColor(ImGuiCol.NavCursor, NavCursorColor);
            PushStyleColor(ImGuiCol.NavWindowingHighlight, NavWindowingHighlightColor);
            PushStyleColor(ImGuiCol.NavWindowingDimBg, NavWindowingDimBgColor);
            PushStyleColor(ImGuiCol.ModalWindowDimBg, ModalWindowDimBgColor);
        }

        public void End()
        {
            ImGui.PopFont();

            if (_styleVarCount > 0)
            {
                ImGui.PopStyleVar(_styleVarCount);
                _styleVarCount = 0;
            }

            if (_styleColorCount > 0)
            {
                ImGui.PopStyleColor(_styleColorCount);
                _styleColorCount = 0;
            }
        }
    }
}

