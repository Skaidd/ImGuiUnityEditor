using System;
using UnityEngine;

namespace ImGuiUnityEditor
{
    /// <summary>
    /// Unity Light style
    /// </summary>
    public class ImGuiLightStyle : ImGuiObjectStyle
    {
        public ImGuiLightStyle()
        {
            FontName = "Inter-Variable";
            Alpha = 1.0f;
            DisabledAlpha = 0.5f;

            WindowPadding = new Vector2(8, 8);
            WindowRounding = 0.0f;
            WindowBorderSize = 1.0f;
            WindowMinSize = new Vector2(32.0f, 32.0f);
            WindowTitleAlign = new Vector2(0.0f, 0.5f);

            ChildRounding = 0.0f;
            ChildBorderSize = 1.0f;

            PopupRounding = 0.0f;
            PopupBorderSize = 1.0f;

            FramePadding = new Vector2(4, 3);
            FrameRounding = 0.0f;
            FrameBorderSize = 1.0f;

            ItemSpacing = new Vector2(4.0f, 2.0f);
            ItemInnerSpacing = new Vector2(4.0f, 4.0f);
            IndentSpacing = 14.0f;
            CellPadding = new Vector2(4.0f, 2.0f);

            ScrollbarSize = 16.0f;
            ScrollbarRounding = 0.0f;
            GrabMinSize = 10.0f;
            GrabRounding = 0.0f;

            ImageBorderSize = 0.0f;

            TabRounding = 0.0f;
            TabBorderSize = 0.0f;
            TabBarBorderSize = 1.0f;
            TabBarOverlineSize = 2.0f;

            TableAngledHeadersAngle = 35.0f;
            TableAngledHeadersTextAlign = new Vector2(0.5f, 0.0f);

            ButtonTextAlign = new Vector2(0.5f, 0.5f);
            SelectableTextAlign = new Vector2(0.0f, 0.0f);

            SeparatorTextBorderSize = 3.0f;
            SeparatorTextAlign = new Vector2(0.0f, 0.5f);
            SeparatorTextPadding = new Vector2(20.0f, 3.0f);

            DockingSeparatorSize = 2.0f;

            TextColor = new Color(0.15f, 0.15f, 0.15f, 1.0f);
            TextDisabledColor = new Color(0.6f, 0.6f, 0.6f, 1.0f);

            WindowBgColor = new Color(0.92f, 0.92f, 0.92f, 0.85f);
            ChildBgColor = new Color(0.0f, 0.0f, 0.0f, 0.0f);
            PopupBgColor = new Color(0.95f, 0.95f, 0.95f, 0.95f);

            BorderColor = new Color(0.7f, 0.7f, 0.7f, 0.8f);
            BorderShadowColor = new Color(0.0f, 0.0f, 0.0f, 0.0f);

            FrameBgColor = new Color(0.98f, 0.98f, 0.98f, 0.8f);
            FrameBgHoveredColor = new Color(1.0f, 1.0f, 1.0f, 0.9f);
            FrameBgActiveColor = new Color(0.94f, 0.94f, 0.94f, 0.9f);

            TitleBgColor = new Color(0.85f, 0.85f, 0.85f, 0.8f);
            TitleBgActiveColor = new Color(0.8f, 0.8f, 0.8f, 0.9f);
            TitleBgCollapsedColor = new Color(0.88f, 0.88f, 0.88f, 0.7f);

            MenuBarBgColor = new Color(0.9f, 0.9f, 0.9f, 0.85f);

            ScrollbarBgColor = new Color(0.95f, 0.95f, 0.95f, 0.6f);
            ScrollbarGrabColor = new Color(0.75f, 0.75f, 0.75f, 0.8f);
            ScrollbarGrabHoveredColor = new Color(0.65f, 0.65f, 0.65f, 0.9f);
            ScrollbarGrabActiveColor = new Color(0.55f, 0.55f, 0.55f, 1.0f);

            CheckMarkColor = new Color(0.24f, 0.48f, 0.85f, 1.0f);
            SliderGrabColor = new Color(0.75f, 0.75f, 0.75f, 0.9f);
            SliderGrabActiveColor = new Color(0.24f, 0.48f, 0.85f, 1.0f);

            ButtonColor = new Color(0.95f, 0.95f, 0.95f, 0.8f);
            ButtonHoveredColor = new Color(0.98f, 0.98f, 0.98f, 0.9f);
            ButtonActiveColor = new Color(0.9f, 0.9f, 0.9f, 0.9f);

            HeaderColor = new Color(0.85f, 0.85f, 0.85f, 0.7f);
            HeaderHoveredColor = new Color(0.9f, 0.9f, 0.9f, 0.8f);
            HeaderActiveColor = new Color(0.24f, 0.48f, 0.85f, 0.8f);

            SeparatorColor = new Color(0.8f, 0.8f, 0.8f, 0.8f);
            SeparatorHoveredColor = new Color(0.24f, 0.48f, 0.85f, 0.8f);
            SeparatorActiveColor = new Color(0.24f, 0.48f, 0.85f, 1.0f);

            ResizeGripColor = new Color(0.7f, 0.7f, 0.7f, 0.15f);
            ResizeGripHoveredColor = new Color(0.24f, 0.48f, 0.85f, 0.5f);
            ResizeGripActiveColor = new Color(0.24f, 0.48f, 0.85f, 0.8f);

            TabColor = new Color(0.8f, 0.8f, 0.8f, 0.7f);
            TabHoveredColor = new Color(0.85f, 0.85f, 0.85f, 0.8f);
            TabSelectedColor = new Color(0.92f, 0.92f, 0.92f, 0.9f);
            TabSelectedOverlineColor = new Color(0.24f, 0.48f, 0.85f, 1.0f);
            TabDimmedColor = new Color(0.75f, 0.75f, 0.75f, 0.6f);
            TabDimmedSelectedColor = new Color(0.85f, 0.85f, 0.85f, 0.7f);
            TabDimmedSelectedOverlineColor = new Color(0.24f, 0.48f, 0.85f, 0.6f);

            DockingPreviewColor = new Color(0.88f, 0.88f, 0.88f, 0.7f);
            DockingEmptyBgColor = new Color(0.96f, 0.96f, 0.96f, 0.9f);

            PlotLinesColor = new Color(0.24f, 0.48f, 0.85f, 1.0f);
            PlotLinesHoveredColor = new Color(0.2f, 0.4f, 0.7f, 1.0f);
            PlotHistogramColor = new Color(0.6f, 0.6f, 0.6f, 1.0f);
            PlotHistogramHoveredColor = new Color(0.24f, 0.48f, 0.85f, 1.0f);

            TableHeaderBgColor = new Color(0.85f, 0.85f, 0.85f, 0.8f);
            TableBorderStrongColor = new Color(0.7f, 0.7f, 0.7f, 0.8f);
            TableBorderLightColor = new Color(0.8f, 0.8f, 0.8f, 0.6f);
            TableRowBgColor = new Color(0.0f, 0.0f, 0.0f, 0.0f);
            TableRowBgAltColor = new Color(0.0f, 0.0f, 0.0f, 0.02f);

            TextLinkColor = new Color(0.24f, 0.48f, 0.85f, 1.0f);
            TextSelectedBgColor = new Color(0.24f, 0.48f, 0.85f, 0.25f);

            DragDropTargetColor = new Color(0.24f, 0.48f, 0.85f, 0.7f);

            NavCursorColor = new Color(0.24f, 0.48f, 0.85f, 1.0f);
            NavWindowingHighlightColor = new Color(0.5f, 0.5f, 0.5f, 0.5f);
            NavWindowingDimBgColor = new Color(0.0f, 0.0f, 0.0f, 0.15f);
            ModalWindowDimBgColor = new Color(0.0f, 0.0f, 0.0f, 0.25f);
        }
    }

    /// <summary>
    /// Unity Dark Style
    /// </summary>
    public class ImGuiDarkStyle : ImGuiObjectStyle
    {
        public ImGuiDarkStyle()
        {
            FontName = "Inter-Variable";
            Alpha = 1.0f;
            DisabledAlpha = 0.5f;

            WindowPadding = new Vector2(8, 8);
            WindowRounding = 0.0f;
            WindowBorderSize = 1.0f;
            WindowMinSize = new Vector2(32.0f, 32.0f);
            WindowTitleAlign = new Vector2(0.0f, 0.5f);

            ChildRounding = 0.0f;
            ChildBorderSize = 1.0f;

            PopupRounding = 0.0f;
            PopupBorderSize = 1.0f;

            FramePadding = new Vector2(4, 3);
            FrameRounding = 0.0f;
            FrameBorderSize = 1.0f;

            ItemSpacing = new Vector2(4.0f, 2.0f);
            ItemInnerSpacing = new Vector2(4.0f, 4.0f);
            IndentSpacing = 14.0f;
            CellPadding = new Vector2(4.0f, 2.0f);

            ScrollbarSize = 16.0f;
            ScrollbarRounding = 0.0f;
            GrabMinSize = 10.0f;
            GrabRounding = 0.0f;

            ImageBorderSize = 0.0f;

            TabRounding = 0.0f;
            TabBorderSize = 0.0f;
            TabBarBorderSize = 1.0f;
            TabBarOverlineSize = 2.0f;

            TableAngledHeadersAngle = 35.0f;
            TableAngledHeadersTextAlign = new Vector2(0.5f, 0.0f);

            ButtonTextAlign = new Vector2(0.5f, 0.5f);
            SelectableTextAlign = new Vector2(0.0f, 0.0f);

            SeparatorTextBorderSize = 3.0f;
            SeparatorTextAlign = new Vector2(0.0f, 0.5f);
            SeparatorTextPadding = new Vector2(20.0f, 3.0f);

            DockingSeparatorSize = 2.0f;

            TextColor = new Color(0.85f, 0.85f, 0.85f, 1.0f);
            TextDisabledColor = new Color(0.55f, 0.55f, 0.55f, 1.0f);

            WindowBgColor = new Color(0.22f, 0.22f, 0.22f, 0.9f);
            ChildBgColor = new Color(0.0f, 0.0f, 0.0f, 0.0f);
            PopupBgColor = new Color(0.25f, 0.25f, 0.25f, 0.95f);

            BorderColor = new Color(0.15f, 0.15f, 0.15f, 0.8f);
            BorderShadowColor = new Color(0.0f, 0.0f, 0.0f, 0.0f);

            FrameBgColor = new Color(0.18f, 0.18f, 0.18f, 0.8f);
            FrameBgHoveredColor = new Color(0.25f, 0.25f, 0.25f, 0.9f);
            FrameBgActiveColor = new Color(0.15f, 0.15f, 0.15f, 0.9f);

            TitleBgColor = new Color(0.2f, 0.2f, 0.2f, 0.85f);
            TitleBgActiveColor = new Color(0.18f, 0.18f, 0.18f, 0.9f);
            TitleBgCollapsedColor = new Color(0.22f, 0.22f, 0.22f, 0.7f);

            MenuBarBgColor = new Color(0.2f, 0.2f, 0.2f, 0.9f);

            ScrollbarBgColor = new Color(0.15f, 0.15f, 0.15f, 0.6f);
            ScrollbarGrabColor = new Color(0.45f, 0.45f, 0.45f, 0.8f);
            ScrollbarGrabHoveredColor = new Color(0.55f, 0.55f, 0.55f, 0.9f);
            ScrollbarGrabActiveColor = new Color(0.65f, 0.65f, 0.65f, 1.0f);

            CheckMarkColor = new Color(0.24f, 0.48f, 0.85f, 1.0f);
            SliderGrabColor = new Color(0.45f, 0.45f, 0.45f, 0.9f);
            SliderGrabActiveColor = new Color(0.24f, 0.48f, 0.85f, 1.0f);

            ButtonColor = new Color(0.25f, 0.25f, 0.25f, 0.8f);
            ButtonHoveredColor = new Color(0.3f, 0.3f, 0.3f, 0.9f);
            ButtonActiveColor = new Color(0.2f, 0.2f, 0.2f, 0.9f);

            HeaderColor = new Color(0.2f, 0.2f, 0.2f, 0.7f);
            HeaderHoveredColor = new Color(0.25f, 0.25f, 0.25f, 0.8f);
            HeaderActiveColor = new Color(0.24f, 0.48f, 0.85f, 0.8f);

            SeparatorColor = new Color(0.35f, 0.35f, 0.35f, 0.8f);
            SeparatorHoveredColor = new Color(0.24f, 0.48f, 0.85f, 0.8f);
            SeparatorActiveColor = new Color(0.24f, 0.48f, 0.85f, 1.0f);

            ResizeGripColor = new Color(0.4f, 0.4f, 0.4f, 0.15f);
            ResizeGripHoveredColor = new Color(0.24f, 0.48f, 0.85f, 0.5f);
            ResizeGripActiveColor = new Color(0.24f, 0.48f, 0.85f, 0.8f);

            TabColor = new Color(0.18f, 0.18f, 0.18f, 0.7f);
            TabHoveredColor = new Color(0.22f, 0.22f, 0.22f, 0.8f);
            TabSelectedColor = new Color(0.22f, 0.22f, 0.22f, 0.9f);
            TabSelectedOverlineColor = new Color(0.24f, 0.48f, 0.85f, 1.0f);
            TabDimmedColor = new Color(0.15f, 0.15f, 0.15f, 0.6f);
            TabDimmedSelectedColor = new Color(0.2f, 0.2f, 0.2f, 0.7f);
            TabDimmedSelectedOverlineColor = new Color(0.24f, 0.48f, 0.85f, 0.6f);

            DockingPreviewColor = new Color(0.3f, 0.3f, 0.3f, 0.7f);
            DockingEmptyBgColor = new Color(0.18f, 0.18f, 0.18f, 0.9f);

            PlotLinesColor = new Color(0.24f, 0.48f, 0.85f, 1.0f);
            PlotLinesHoveredColor = new Color(0.3f, 0.55f, 0.9f, 1.0f);
            PlotHistogramColor = new Color(0.7f, 0.7f, 0.7f, 1.0f);
            PlotHistogramHoveredColor = new Color(0.24f, 0.48f, 0.85f, 1.0f);

            TableHeaderBgColor = new Color(0.2f, 0.2f, 0.2f, 0.8f);
            TableBorderStrongColor = new Color(0.15f, 0.15f, 0.15f, 0.8f);
            TableBorderLightColor = new Color(0.25f, 0.25f, 0.25f, 0.6f);
            TableRowBgColor = new Color(0.0f, 0.0f, 0.0f, 0.0f);
            TableRowBgAltColor = new Color(1.0f, 1.0f, 1.0f, 0.02f);

            TextLinkColor = new Color(0.24f, 0.48f, 0.85f, 1.0f);
            TextSelectedBgColor = new Color(0.24f, 0.48f, 0.85f, 0.25f);

            DragDropTargetColor = new Color(0.24f, 0.48f, 0.85f, 0.7f);

            NavCursorColor = new Color(0.24f, 0.48f, 0.85f, 1.0f);
            NavWindowingHighlightColor = new Color(0.5f, 0.5f, 0.5f, 0.5f);
            NavWindowingDimBgColor = new Color(0.0f, 0.0f, 0.0f, 0.4f);
            ModalWindowDimBgColor = new Color(0.0f, 0.0f, 0.0f, 0.6f);
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

        [field: SerializeField] public string FontName { get; set; } = default;
        [field: SerializeField] public float Alpha { get; set; } = default;
        [field: SerializeField] public float DisabledAlpha { get; set; } = default;
        [field: SerializeField] public Vector2 WindowPadding { get; set; } = default;
        [field: SerializeField] public float WindowRounding { get; set; } = default;
        [field: SerializeField] public float WindowBorderSize { get; set; } = default;
        [field: SerializeField] public Vector2 WindowMinSize { get; set; } = default;
        [field: SerializeField] public Vector2 WindowTitleAlign { get; set; } = default;
        [field: SerializeField] public float ChildRounding { get; set; } = default;
        [field: SerializeField] public float ChildBorderSize { get; set; } = default;
        [field: SerializeField] public float PopupRounding { get; set; } = default;
        [field: SerializeField] public float PopupBorderSize { get; set; } = default;
        [field: SerializeField] public Vector2 FramePadding { get; set; } = default;
        [field: SerializeField] public float FrameRounding { get; set; } = default;
        [field: SerializeField] public float FrameBorderSize { get; set; } = default;
        [field: SerializeField] public Vector2 ItemSpacing { get; set; } = default;
        [field: SerializeField] public Vector2 ItemInnerSpacing { get; set; } = default;
        [field: SerializeField] public float IndentSpacing { get; set; } = default;
        [field: SerializeField] public Vector2 CellPadding { get; set; } = default;
        [field: SerializeField] public float ScrollbarSize { get; set; } = default;
        [field: SerializeField] public float ScrollbarRounding { get; set; } = default;
        [field: SerializeField] public float GrabMinSize { get; set; } = default;
        [field: SerializeField] public float GrabRounding { get; set; } = default;
        [field: SerializeField] public float ImageBorderSize { get; set; } = default;
        [field: SerializeField] public float TabRounding { get; set; } = default;
        [field: SerializeField] public float TabBorderSize { get; set; } = default;
        [field: SerializeField] public float TabBarBorderSize { get; set; } = default;
        [field: SerializeField] public float TabBarOverlineSize { get; set; } = default;
        [field: SerializeField] public float TableAngledHeadersAngle { get; set; } = default;
        [field: SerializeField] public Vector2 TableAngledHeadersTextAlign { get; set; } = default;
        [field: SerializeField] public Vector2 ButtonTextAlign { get; set; } = default;
        [field: SerializeField] public Vector2 SelectableTextAlign { get; set; } = default;
        [field: SerializeField] public float SeparatorTextBorderSize { get; set; } = default;
        [field: SerializeField] public Vector2 SeparatorTextAlign { get; set; } = default;
        [field: SerializeField] public Vector2 SeparatorTextPadding { get; set; } = default;
        [field: SerializeField] public float DockingSeparatorSize { get; set; } = default;

        [field: SerializeField] public Color TextColor { get; set; } = default;
        [field: SerializeField] public Color TextDisabledColor { get; set; } = default;
        [field: SerializeField] public Color WindowBgColor { get; set; } = default;
        [field: SerializeField] public Color ChildBgColor { get; set; } = default;
        [field: SerializeField] public Color PopupBgColor { get; set; } = default;
        [field: SerializeField] public Color BorderColor { get; set; } = default;
        [field: SerializeField] public Color BorderShadowColor { get; set; } = default;
        [field: SerializeField] public Color FrameBgColor { get; set; } = default;
        [field: SerializeField] public Color FrameBgHoveredColor { get; set; } = default;
        [field: SerializeField] public Color FrameBgActiveColor { get; set; } = default;
        [field: SerializeField] public Color TitleBgColor { get; set; } = default;
        [field: SerializeField] public Color TitleBgActiveColor { get; set; } = default;
        [field: SerializeField] public Color TitleBgCollapsedColor { get; set; } = default;
        [field: SerializeField] public Color MenuBarBgColor { get; set; } = default;
        [field: SerializeField] public Color ScrollbarBgColor { get; set; } = default;
        [field: SerializeField] public Color ScrollbarGrabColor { get; set; } = default;
        [field: SerializeField] public Color ScrollbarGrabHoveredColor { get; set; } = default;
        [field: SerializeField] public Color ScrollbarGrabActiveColor { get; set; } = default;
        [field: SerializeField] public Color CheckMarkColor { get; set; } = default;
        [field: SerializeField] public Color SliderGrabColor { get; set; } = default;
        [field: SerializeField] public Color SliderGrabActiveColor { get; set; } = default;
        [field: SerializeField] public Color ButtonColor { get; set; } = default;
        [field: SerializeField] public Color ButtonHoveredColor { get; set; } = default;
        [field: SerializeField] public Color ButtonActiveColor { get; set; } = default;
        [field: SerializeField] public Color HeaderColor { get; set; } = default;
        [field: SerializeField] public Color HeaderHoveredColor { get; set; } = default;
        [field: SerializeField] public Color HeaderActiveColor { get; set; } = default;
        [field: SerializeField] public Color SeparatorColor { get; set; } = default;
        [field: SerializeField] public Color SeparatorHoveredColor { get; set; } = default;
        [field: SerializeField] public Color SeparatorActiveColor { get; set; } = default;
        [field: SerializeField] public Color ResizeGripColor { get; set; } = default;
        [field: SerializeField] public Color ResizeGripHoveredColor { get; set; } = default;
        [field: SerializeField] public Color ResizeGripActiveColor { get; set; } = default;
        [field: SerializeField] public Color TabColor { get; set; } = default;
        [field: SerializeField] public Color TabHoveredColor { get; set; } = default;
        [field: SerializeField] public Color TabSelectedColor { get; set; } = default;
        [field: SerializeField] public Color TabSelectedOverlineColor { get; set; } = default;
        [field: SerializeField] public Color TabDimmedColor { get; set; } = default;
        [field: SerializeField] public Color TabDimmedSelectedColor { get; set; } = default;
        [field: SerializeField] public Color TabDimmedSelectedOverlineColor { get; set; } = default;
        [field: SerializeField] public Color DockingPreviewColor { get; set; } = default;
        [field: SerializeField] public Color DockingEmptyBgColor { get; set; } = default;
        [field: SerializeField] public Color PlotLinesColor { get; set; } = default;
        [field: SerializeField] public Color PlotLinesHoveredColor { get; set; } = default;
        [field: SerializeField] public Color PlotHistogramColor { get; set; } = default;
        [field: SerializeField] public Color PlotHistogramHoveredColor { get; set; } = default;
        [field: SerializeField] public Color TableHeaderBgColor { get; set; } = default;
        [field: SerializeField] public Color TableBorderStrongColor { get; set; } = default;
        [field: SerializeField] public Color TableBorderLightColor { get; set; } = default;
        [field: SerializeField] public Color TableRowBgColor { get; set; } = default;
        [field: SerializeField] public Color TableRowBgAltColor { get; set; } = default;
        [field: SerializeField] public Color TextLinkColor { get; set; } = default;
        [field: SerializeField] public Color TextSelectedBgColor { get; set; } = default;
        [field: SerializeField] public Color DragDropTargetColor { get; set; } = default;
        [field: SerializeField] public Color NavCursorColor { get; set; } = default;
        [field: SerializeField] public Color NavWindowingHighlightColor { get; set; } = default;
        [field: SerializeField] public Color NavWindowingDimBgColor { get; set; } = default;
        [field: SerializeField] public Color ModalWindowDimBgColor { get; set; } = default;

        private void PushFont(string fontName)
        {
            if (fontName == default) return;

            var font = ImGui.GetIO().Fonts.GetFont(fontName);
            ImGui.PushFont(font, font.LegacySize);
        }

        private void PushStyleVar(ImGuiStyleVar styleVar, float value)
        {
            if (value == default) return;

            ImGui.PushStyleVar(styleVar, value);
            _styleVarCount++;
        }

        private void PushStyleVar(ImGuiStyleVar styleVar, Vector2 value)
        {
            if (value == default) return;

            ImGui.PushStyleVar(styleVar, new Vector2(value.x, value.y));
            _styleVarCount++;
        }

        private void PushStyleColor(ImGuiCol colorId, Color color)
        {
            if (color == default) return;

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
            this.ImageBorderSize = style.ImageBorderSize;
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
            PushStyleVar(ImGuiStyleVar.ImageBorderSize, ImageBorderSize);
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
            if (FontName != default)
            {
                ImGui.PopFont();
            }

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
