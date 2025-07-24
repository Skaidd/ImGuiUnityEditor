using UnityEngine;
using System;
using System.Runtime.InteropServices;
using UnityEngine.Rendering;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Collections;
using UnityEditor;
using System.Runtime.CompilerServices;

namespace ImGuiUnityEditor
{
    /// <summary>
    /// Handles the rendering of ImGui draw data to Unity's Editor
    /// </summary>
    public class ImGuiRenderer : IDisposable
    {
        // Shader properties
        private readonly int _vertexProperty = Shader.PropertyToID("_Vertices");
        private readonly int _textureProperty = Shader.PropertyToID("_Texture");
        private readonly int _baseVertexProperty = Shader.PropertyToID("_BaseVertex");
        private readonly string _shaderPath = "Shaders/DearImGui";

        // Graphics buffers
        private GraphicsBuffer _vertexBuffer;
        private GraphicsBuffer _indexBuffer;
        private GraphicsBuffer _argsBuffer;

        // ImGui resources
        public ImGuiContextPtr _imGuiContext;
        private ImPlotContextPtr _imPlotContext;
        private ImNodesContextPtr _imNodesContext;
        private double _lastTime = 0;

        // Rendering resources
        private CommandBuffer _cmd;
        private Material _material;
        private readonly MaterialPropertyBlock _materialPropertyBlock;
        private RenderTexture _renderTexture;

        // ImGui IO 
        public ImGuiIOPtr IO { get; private set; }

        // Input handler
        public ImGuiRendererInputHandler InputHandler { get; private set; }

        /// <summary>
        /// Initializes the ImGui renderer
        /// </summary>
        public unsafe ImGuiRenderer()
        {
            try
            {
                //* Create command buffer
                _cmd = new CommandBuffer()
                {
                    name = $"{GetType().Name} ImGUI Command Buffer"
                };

                //* Create material
                Shader shader = Resources.Load<Shader>(_shaderPath);
                if (shader == null)
                {
                    Debug.LogError("ImGuiUnity shader not found! Make sure DearImGui.shader exists in your Resources/Shaders folder.");
                    return;
                }

                _material = new(shader);
#if UNITY_EDITOR
                _material.hideFlags = HideFlags.HideAndDontSave;
#endif

                //* Create render texture
                _renderTexture = new RenderTexture(1, 1, 24, RenderTextureFormat.ARGB32);
#if UNITY_EDITOR
                _renderTexture.hideFlags = HideFlags.HideAndDontSave;
#endif
                _renderTexture.Create();

                //* Create material property block
                _materialPropertyBlock = new MaterialPropertyBlock();

                //* Setup ImGui
                _imGuiContext = ImGui.CreateContext();
                ImGui.SetCurrentContext(_imGuiContext);

                //* Setup ImPlot
                ImPlot.SetImGuiContext(_imGuiContext);
                _imPlotContext = ImPlot.CreateContext();
                ImPlot.SetCurrentContext(_imPlotContext);
                ImPlot.StyleColorsDark(ImPlot.GetStyle());

                //* Setup ImNodes
                ImNodes.SetImGuiContext(_imGuiContext);
                _imNodesContext = ImNodes.CreateContext();
                ImNodes.SetCurrentContext(_imNodesContext);
                ImNodes.StyleColorsDark(ImNodes.GetStyle());

                //* Setup ImGuizmo
                ImGuizmo.SetImGuiContext(_imGuiContext);

                IO = ImGui.GetIO();

                //* Set up ImGui configuration
                IO.BackendFlags |= ImGuiBackendFlags.RendererHasVtxOffset;
                IO.BackendFlags |= ImGuiBackendFlags.RendererHasTextures;
                IO.ConfigFlags |= ImGuiConfigFlags.NavEnableKeyboard;
                IO.ConfigFlags |= ImGuiConfigFlags.NavEnableGamepad;
                IO.ConfigFlags |= ImGuiConfigFlags.DockingEnable;
                IO.ConfigInputTextCursorBlink = true;
                IO.ConfigErrorRecovery = true;
                IO.ConfigErrorRecoveryEnableAssert = false;
                IO.ConfigErrorRecoveryEnableTooltip = true;

                // //* Set Initial display size
                // IO.DisplaySize = new(1, 1);

                //* Disable ImGui's automatic INI file handling and log file handling
                var io = ImGui.GetIO();
                io.IniFilename = (byte*)IntPtr.Zero;
                io.LogFilename = (byte*)IntPtr.Zero;

                LoadAllFonts();
            }
            catch (Exception e)
            {
                Debug.LogError($"Error initializing ImGui renderer: {e.Message}\n{e.StackTrace}");
                Dispose();
            }
        }

        /// <summary>
        /// Loads all fonts
        /// </summary>
        public unsafe void LoadAllFonts([CallerFilePath] string sourceFilePath = "")
        {
            string scriptDirectory = System.IO.Path.GetDirectoryName(sourceFilePath);
            string fontsDirectory = System.IO.Path.Combine(scriptDirectory, "Resources");

            var builtInFonts = new[]
            {
                (name: "Inter-Variable.ttf", mergeMode: false),
                (name: "codicon.ttf", mergeMode: true),
                (name: "lucide.ttf", mergeMode: true),
                (name: "MaterialIcons-Regular.ttf", mergeMode: true),
                (name: "fontaudio.ttf", mergeMode: true),
                (name: "seguiemj.ttf", mergeMode: true),
                (name: "NotoSansJP-Regular.ttf", mergeMode: true)
            };

            var builtInFontConfig = new ImFontConfig
            {
                MergeMode = 1,
                RasterizerDensity = 1,
                RasterizerMultiply = 1,
                GlyphMinAdvanceX = 0,
                GlyphMaxAdvanceX = 13,
                FontLoaderFlags = (uint)ImGuiFreeTypeLoaderFlags.LoadColor,
            };

            foreach (var (name, mergeMode) in builtInFonts)
            {
                string fontPath = System.IO.Path.Combine(fontsDirectory, name);

                if (System.IO.File.Exists(fontPath))
                {
                    if (mergeMode)
                        IO.Fonts.AddFontFromFileTTF(fontPath, 16, ref builtInFontConfig);
                    else
                        IO.Fonts.AddFontFromFileTTF(fontPath, 16);
                }
                else
                {
                    Debug.LogWarning($"Built-in font not found: {fontPath}");
                }
            }

            var customFonts = Resources.LoadAll<Font>("ImguiEditorFonts");
            foreach (var font in customFonts)
            {
                var fontPath = AssetDatabase.GetAssetPath(font);
                IO.Fonts.AddFontFromFileTTF(fontPath, 16);
            }
        }

        /// <summary>
        /// Sets up the ImGui context.
        /// </summary>
        public void SetupContext()
        {
            try
            {
                ImGui.SetCurrentContext(_imGuiContext);
                ImPlot.SetCurrentContext(_imPlotContext);
                ImNodes.SetCurrentContext(_imNodesContext);

                ImPlot.SetImGuiContext(_imGuiContext);
                ImNodes.SetImGuiContext(_imGuiContext);
                ImGuizmo.SetImGuiContext(_imGuiContext);
            }
            catch (Exception e)
            {
                Debug.LogError($"Error setting up ImGui context: {e.Message}\n{e.StackTrace}");
            }

        }

        /// <summary>
        /// Sets the input handler.
        /// </summary>
        /// <typeparam name="T">The type of the input handler.</typeparam>
        public void SetInputHandler<T>() where T : ImGuiRendererInputHandler, new()
        {
            InputHandler = new T();
            InputHandler.SetIO(IO);
        }

        /// <summary>
        /// Sets the input handler.
        /// </summary>
        /// <param name="inputHandler">The input handler to set.</param>
        public void SetInputHandler(ImGuiRendererInputHandler inputHandler)
        {
            InputHandler = inputHandler;
            InputHandler.SetIO(IO);
        }

        /// <summary>
        /// Resizes ImGui display with proper DPI handling
        /// </summary>
        /// <param name="size">The logical size.</param>
        private void Resize(Vector2 size)
        {
            try
            {
                if (size.x >= 0 && size.y >= 0)
                {
#if UNITY_EDITOR
                    float dpiScale = UnityEditor.EditorGUIUtility.pixelsPerPoint;
#else
                float dpiScale = Screen.dpi / 96.0f;
#endif

                    IO.DisplaySize = size;

                    IO.DisplayFramebufferScale = new Vector2(dpiScale, dpiScale);

                    int physicalWidth = Mathf.RoundToInt(size.x * dpiScale);
                    int physicalHeight = Mathf.RoundToInt(size.y * dpiScale);

                    if (_renderTexture != null &&
                        (_renderTexture.width != physicalWidth || _renderTexture.height != physicalHeight))
                    {
                        _renderTexture.Release();
                        _renderTexture.width = Mathf.Max(1, physicalWidth);
                        _renderTexture.height = Mathf.Max(1, physicalHeight);
                        _renderTexture.Create();
                    }
                }
            }
            catch (Exception e)
            {
                Debug.LogError($"Error resizing ImGui display: {e.Message}\n{e.StackTrace}");
            }
        }

        /// <summary>
        /// Begins a new ImGui frame.
        /// </summary>
        /// <param name="size">The logical size of ImGui display.</param>
        private void Begin(Vector2 size)
        {
            SetupContext();
            Resize(size);

#if UNITY_EDITOR
            double time = EditorApplication.timeSinceStartup;
#else
            double time = Time.realtimeSinceStartup;
#endif
            double deltaTime = time - _lastTime;
            IO.DeltaTime = (float)deltaTime;
            _lastTime = time;

            try
            {
                ImGui.NewFrame();
                ImGuizmo.BeginFrame();
            }
            catch (Exception e)
            {
                Debug.LogError($"Error beginning ImGui frame: {e.Message}\n{e.StackTrace}");
            }

            InputHandler?.UpdateInput();
        }

        /// <summary>
        /// Ends the ImGui frame and renders the draw data.
        /// </summary>
        /// <returns>RenderTexture.</returns>
        private RenderTexture End()
        {
            try
            {
                ImGui.Render();
                RenderImGuiDrawData(ImGui.GetDrawData());
                return _renderTexture;
            }
            catch (Exception e)
            {
                Debug.LogError($"Error ending ImGui frame: {e.Message}\n{e.StackTrace}");
                return _renderTexture;
            }
        }

        /// <summary>
        /// Renders ImGui frame.
        /// </summary>
        /// <param name="size">The logical size of ImGui display.</param>
        /// <param name="draw">The action to draw ImGui content.</param>
        /// <returns>RenderTexture.</returns>
        public unsafe RenderTexture Render(Vector2 size, Action draw)
        {
            IO.ConfigErrorRecoveryEnableAssert = false;

            Begin(size);

            try
            {
                draw();
            }
            catch (Exception e)
            {
                string stackTrace = e.StackTrace.Split('\n')[0].Trim();
                string errorMessage = $"{e.Message}\n{stackTrace}";
                Debug.LogError(errorMessage);

                ImGuiP.ErrorLog(e.Message);
                ImGuiP.BeginErrorTooltip();
                if (ImGui.TextLink(stackTrace))
                {
                    var match = System.Text.RegularExpressions.Regex.Match(stackTrace, @" in (.*):(\d+)");
                    if (match.Success)
                    {
                        var filePath = match.Groups[1].Value;
                        var lineNumber = int.Parse(match.Groups[2].Value);
                        UnityEditorInternal.InternalEditorUtility.TryOpenErrorFileFromConsole(filePath, lineNumber, 0);
                    }
                }
                ImGuiP.EndErrorTooltip();

                ImGui.End();
            }

            End();

            return _renderTexture;
        }

        /// <summary>
        /// Saves the ImGui settings.
        /// </summary>
        /// <returns>The ImGui settings.</returns>
        public unsafe string SaveSettings()
        {
            SetupContext();
            string iniData = Marshal.PtrToStringAnsi(new IntPtr(ImGui.SaveIniSettingsToMemory()));
            return iniData;
        }

        /// <summary>
        /// Loads the ImGui settings.
        /// </summary>
        /// <param name="iniData">The ImGui settings.</param>
        public void LoadSettings(string iniData)
        {
            if (string.IsNullOrEmpty(iniData)) { return; }
            SetupContext();
            ImGui.LoadIniSettingsFromMemory(iniData);
        }

        /// <summary>
        /// Sets the style.
        /// </summary>
        /// <typeparam name="T">The type of the style.</typeparam>
        public void SetStyle<T>() where T : ImGuiObjectStyle, new()
        {
            var style = new T();
            SetStyle(style);
        }

        /// <summary>
        /// Sets the style.
        /// </summary>
        /// <param name="style">The style to set.</param>
        public void SetStyle(ImGuiObjectStyle style)
        {
            var currentStyle = ImGui.GetStyle();

            IO.FontDefault = IO.Fonts.GetFont(style.FontName) != default(ImFontPtr) ? IO.Fonts.GetFont(style.FontName) : IO.FontDefault;

            currentStyle.Alpha = style.Alpha != default ? style.Alpha : currentStyle.Alpha;
            currentStyle.DisabledAlpha = style.DisabledAlpha != default ? style.DisabledAlpha : currentStyle.DisabledAlpha;
            currentStyle.WindowPadding = style.WindowPadding != default ? style.WindowPadding : currentStyle.WindowPadding;
            currentStyle.WindowRounding = style.WindowRounding != default ? style.WindowRounding : currentStyle.WindowRounding;
            currentStyle.WindowBorderSize = style.WindowBorderSize != default ? style.WindowBorderSize : currentStyle.WindowBorderSize;
            currentStyle.WindowMinSize = style.WindowMinSize != default ? style.WindowMinSize : currentStyle.WindowMinSize;
            currentStyle.WindowTitleAlign = style.WindowTitleAlign != default ? style.WindowTitleAlign : currentStyle.WindowTitleAlign;
            currentStyle.ChildRounding = style.ChildRounding != default ? style.ChildRounding : currentStyle.ChildRounding;
            currentStyle.ChildBorderSize = style.ChildBorderSize != default ? style.ChildBorderSize : currentStyle.ChildBorderSize;
            currentStyle.PopupRounding = style.PopupRounding != default ? style.PopupRounding : currentStyle.PopupRounding;
            currentStyle.PopupBorderSize = style.PopupBorderSize != default ? style.PopupBorderSize : currentStyle.PopupBorderSize;
            currentStyle.FramePadding = style.FramePadding != default ? style.FramePadding : currentStyle.FramePadding;
            currentStyle.FrameRounding = style.FrameRounding != default ? style.FrameRounding : currentStyle.FrameRounding;
            currentStyle.FrameBorderSize = style.FrameBorderSize != default ? style.FrameBorderSize : currentStyle.FrameBorderSize;
            currentStyle.ItemSpacing = style.ItemSpacing != default ? style.ItemSpacing : currentStyle.ItemSpacing;
            currentStyle.ItemInnerSpacing = style.ItemInnerSpacing != default ? style.ItemInnerSpacing : currentStyle.ItemInnerSpacing;
            currentStyle.IndentSpacing = style.IndentSpacing != default ? style.IndentSpacing : currentStyle.IndentSpacing;
            currentStyle.CellPadding = style.CellPadding != default ? style.CellPadding : currentStyle.CellPadding;
            currentStyle.ScrollbarSize = style.ScrollbarSize != default ? style.ScrollbarSize : currentStyle.ScrollbarSize;
            currentStyle.ScrollbarRounding = style.ScrollbarRounding != default ? style.ScrollbarRounding : currentStyle.ScrollbarRounding;
            currentStyle.GrabMinSize = style.GrabMinSize != default ? style.GrabMinSize : currentStyle.GrabMinSize;
            currentStyle.GrabRounding = style.GrabRounding != default ? style.GrabRounding : currentStyle.GrabRounding;
            currentStyle.ImageBorderSize = style.ImageBorderSize != default ? style.ImageBorderSize : currentStyle.ImageBorderSize;
            currentStyle.TabRounding = style.TabRounding != default ? style.TabRounding : currentStyle.TabRounding;
            currentStyle.TabBorderSize = style.TabBorderSize != default ? style.TabBorderSize : currentStyle.TabBorderSize;
            currentStyle.TabBarBorderSize = style.TabBarBorderSize != default ? style.TabBarBorderSize : currentStyle.TabBarBorderSize;
            currentStyle.TabBarOverlineSize = style.TabBarOverlineSize != default ? style.TabBarOverlineSize : currentStyle.TabBarOverlineSize;
            currentStyle.TableAngledHeadersAngle = style.TableAngledHeadersAngle != default ? style.TableAngledHeadersAngle : currentStyle.TableAngledHeadersAngle;
            currentStyle.TableAngledHeadersTextAlign = style.TableAngledHeadersTextAlign != default ? style.TableAngledHeadersTextAlign : currentStyle.TableAngledHeadersTextAlign;
            currentStyle.ButtonTextAlign = style.ButtonTextAlign != default ? style.ButtonTextAlign : currentStyle.ButtonTextAlign;
            currentStyle.SelectableTextAlign = style.SelectableTextAlign != default ? style.SelectableTextAlign : currentStyle.SelectableTextAlign;
            currentStyle.SeparatorTextBorderSize = style.SeparatorTextBorderSize != default ? style.SeparatorTextBorderSize : currentStyle.SeparatorTextBorderSize;
            currentStyle.SeparatorTextAlign = style.SeparatorTextAlign != default ? style.SeparatorTextAlign : currentStyle.SeparatorTextAlign;
            currentStyle.SeparatorTextPadding = style.SeparatorTextPadding != default ? style.SeparatorTextPadding : currentStyle.SeparatorTextPadding;
            currentStyle.DockingSeparatorSize = style.DockingSeparatorSize != default ? style.DockingSeparatorSize : currentStyle.DockingSeparatorSize;

            currentStyle.Colors[(int)ImGuiCol.Text] = style.TextColor != default ? style.TextColor : currentStyle.Colors[(int)ImGuiCol.Text];
            currentStyle.Colors[(int)ImGuiCol.TextDisabled] = style.TextDisabledColor != default ? style.TextDisabledColor : currentStyle.Colors[(int)ImGuiCol.TextDisabled];
            currentStyle.Colors[(int)ImGuiCol.WindowBg] = style.WindowBgColor != default ? style.WindowBgColor : currentStyle.Colors[(int)ImGuiCol.WindowBg];
            currentStyle.Colors[(int)ImGuiCol.ChildBg] = style.ChildBgColor != default ? style.ChildBgColor : currentStyle.Colors[(int)ImGuiCol.ChildBg];
            currentStyle.Colors[(int)ImGuiCol.PopupBg] = style.PopupBgColor != default ? style.PopupBgColor : currentStyle.Colors[(int)ImGuiCol.PopupBg];
            currentStyle.Colors[(int)ImGuiCol.Border] = style.BorderColor != default ? style.BorderColor : currentStyle.Colors[(int)ImGuiCol.Border];
            currentStyle.Colors[(int)ImGuiCol.BorderShadow] = style.BorderShadowColor != default ? style.BorderShadowColor : currentStyle.Colors[(int)ImGuiCol.BorderShadow];
            currentStyle.Colors[(int)ImGuiCol.FrameBg] = style.FrameBgColor != default ? style.FrameBgColor : currentStyle.Colors[(int)ImGuiCol.FrameBg];
            currentStyle.Colors[(int)ImGuiCol.FrameBgHovered] = style.FrameBgHoveredColor != default ? style.FrameBgHoveredColor : currentStyle.Colors[(int)ImGuiCol.FrameBgHovered];
            currentStyle.Colors[(int)ImGuiCol.FrameBgActive] = style.FrameBgActiveColor != default ? style.FrameBgActiveColor : currentStyle.Colors[(int)ImGuiCol.FrameBgActive];
            currentStyle.Colors[(int)ImGuiCol.TitleBg] = style.TitleBgColor != default ? style.TitleBgColor : currentStyle.Colors[(int)ImGuiCol.TitleBg];
            currentStyle.Colors[(int)ImGuiCol.TitleBgActive] = style.TitleBgActiveColor != default ? style.TitleBgActiveColor : currentStyle.Colors[(int)ImGuiCol.TitleBgActive];
            currentStyle.Colors[(int)ImGuiCol.TitleBgCollapsed] = style.TitleBgCollapsedColor != default ? style.TitleBgCollapsedColor : currentStyle.Colors[(int)ImGuiCol.TitleBgCollapsed];
            currentStyle.Colors[(int)ImGuiCol.MenuBarBg] = style.MenuBarBgColor != default ? style.MenuBarBgColor : currentStyle.Colors[(int)ImGuiCol.MenuBarBg];
            currentStyle.Colors[(int)ImGuiCol.ScrollbarBg] = style.ScrollbarBgColor != default ? style.ScrollbarBgColor : currentStyle.Colors[(int)ImGuiCol.ScrollbarBg];
            currentStyle.Colors[(int)ImGuiCol.ScrollbarGrab] = style.ScrollbarGrabColor != default ? style.ScrollbarGrabColor : currentStyle.Colors[(int)ImGuiCol.ScrollbarGrab];
            currentStyle.Colors[(int)ImGuiCol.ScrollbarGrabHovered] = style.ScrollbarGrabHoveredColor != default ? style.ScrollbarGrabHoveredColor : currentStyle.Colors[(int)ImGuiCol.ScrollbarGrabHovered];
            currentStyle.Colors[(int)ImGuiCol.ScrollbarGrabActive] = style.ScrollbarGrabActiveColor != default ? style.ScrollbarGrabActiveColor : currentStyle.Colors[(int)ImGuiCol.ScrollbarGrabActive];
            currentStyle.Colors[(int)ImGuiCol.CheckMark] = style.CheckMarkColor != default ? style.CheckMarkColor : currentStyle.Colors[(int)ImGuiCol.CheckMark];
            currentStyle.Colors[(int)ImGuiCol.SliderGrab] = style.SliderGrabColor != default ? style.SliderGrabColor : currentStyle.Colors[(int)ImGuiCol.SliderGrab];
            currentStyle.Colors[(int)ImGuiCol.SliderGrabActive] = style.SliderGrabActiveColor != default ? style.SliderGrabActiveColor : currentStyle.Colors[(int)ImGuiCol.SliderGrabActive];
            currentStyle.Colors[(int)ImGuiCol.Button] = style.ButtonColor != default ? style.ButtonColor : currentStyle.Colors[(int)ImGuiCol.Button];
            currentStyle.Colors[(int)ImGuiCol.ButtonHovered] = style.ButtonHoveredColor != default ? style.ButtonHoveredColor : currentStyle.Colors[(int)ImGuiCol.ButtonHovered];
            currentStyle.Colors[(int)ImGuiCol.ButtonActive] = style.ButtonActiveColor != default ? style.ButtonActiveColor : currentStyle.Colors[(int)ImGuiCol.ButtonActive];
            currentStyle.Colors[(int)ImGuiCol.Header] = style.HeaderColor != default ? style.HeaderColor : currentStyle.Colors[(int)ImGuiCol.Header];
            currentStyle.Colors[(int)ImGuiCol.HeaderHovered] = style.HeaderHoveredColor != default ? style.HeaderHoveredColor : currentStyle.Colors[(int)ImGuiCol.HeaderHovered];
            currentStyle.Colors[(int)ImGuiCol.HeaderActive] = style.HeaderActiveColor != default ? style.HeaderActiveColor : currentStyle.Colors[(int)ImGuiCol.HeaderActive];
            currentStyle.Colors[(int)ImGuiCol.Separator] = style.SeparatorColor != default ? style.SeparatorColor : currentStyle.Colors[(int)ImGuiCol.Separator];
            currentStyle.Colors[(int)ImGuiCol.SeparatorHovered] = style.SeparatorHoveredColor != default ? style.SeparatorHoveredColor : currentStyle.Colors[(int)ImGuiCol.SeparatorHovered];
            currentStyle.Colors[(int)ImGuiCol.SeparatorActive] = style.SeparatorActiveColor != default ? style.SeparatorActiveColor : currentStyle.Colors[(int)ImGuiCol.SeparatorActive];
            currentStyle.Colors[(int)ImGuiCol.ResizeGrip] = style.ResizeGripColor != default ? style.ResizeGripColor : currentStyle.Colors[(int)ImGuiCol.ResizeGrip];
            currentStyle.Colors[(int)ImGuiCol.ResizeGripHovered] = style.ResizeGripHoveredColor != default ? style.ResizeGripHoveredColor : currentStyle.Colors[(int)ImGuiCol.ResizeGripHovered];
            currentStyle.Colors[(int)ImGuiCol.ResizeGripActive] = style.ResizeGripActiveColor != default ? style.ResizeGripActiveColor : currentStyle.Colors[(int)ImGuiCol.ResizeGripActive];
            currentStyle.Colors[(int)ImGuiCol.Tab] = style.TabColor != default ? style.TabColor : currentStyle.Colors[(int)ImGuiCol.Tab];
            currentStyle.Colors[(int)ImGuiCol.TabHovered] = style.TabHoveredColor != default ? style.TabHoveredColor : currentStyle.Colors[(int)ImGuiCol.TabHovered];
            currentStyle.Colors[(int)ImGuiCol.TabSelected] = style.TabSelectedColor != default ? style.TabSelectedColor : currentStyle.Colors[(int)ImGuiCol.TabSelected];
            currentStyle.Colors[(int)ImGuiCol.TabSelectedOverline] = style.TabSelectedOverlineColor != default ? style.TabSelectedOverlineColor : currentStyle.Colors[(int)ImGuiCol.TabSelectedOverline];
            currentStyle.Colors[(int)ImGuiCol.TabDimmed] = style.TabDimmedColor != default ? style.TabDimmedColor : currentStyle.Colors[(int)ImGuiCol.TabDimmed];
            currentStyle.Colors[(int)ImGuiCol.TabDimmedSelected] = style.TabDimmedSelectedColor != default ? style.TabDimmedSelectedColor : currentStyle.Colors[(int)ImGuiCol.TabDimmedSelected];
            currentStyle.Colors[(int)ImGuiCol.TabDimmedSelectedOverline] = style.TabDimmedSelectedOverlineColor != default ? style.TabDimmedSelectedOverlineColor : currentStyle.Colors[(int)ImGuiCol.TabDimmedSelectedOverline];
            currentStyle.Colors[(int)ImGuiCol.DockingPreview] = style.DockingPreviewColor != default ? style.DockingPreviewColor : currentStyle.Colors[(int)ImGuiCol.DockingPreview];
            currentStyle.Colors[(int)ImGuiCol.DockingEmptyBg] = style.DockingEmptyBgColor != default ? style.DockingEmptyBgColor : currentStyle.Colors[(int)ImGuiCol.DockingEmptyBg];
            currentStyle.Colors[(int)ImGuiCol.PlotLines] = style.PlotLinesColor != default ? style.PlotLinesColor : currentStyle.Colors[(int)ImGuiCol.PlotLines];
            currentStyle.Colors[(int)ImGuiCol.PlotLinesHovered] = style.PlotLinesHoveredColor != default ? style.PlotLinesHoveredColor : currentStyle.Colors[(int)ImGuiCol.PlotLinesHovered];
            currentStyle.Colors[(int)ImGuiCol.PlotHistogram] = style.PlotHistogramColor != default ? style.PlotHistogramColor : currentStyle.Colors[(int)ImGuiCol.PlotHistogram];
            currentStyle.Colors[(int)ImGuiCol.PlotHistogramHovered] = style.PlotHistogramHoveredColor != default ? style.PlotHistogramHoveredColor : currentStyle.Colors[(int)ImGuiCol.PlotHistogramHovered];
            currentStyle.Colors[(int)ImGuiCol.TableHeaderBg] = style.TableHeaderBgColor != default ? style.TableHeaderBgColor : currentStyle.Colors[(int)ImGuiCol.TableHeaderBg];
            currentStyle.Colors[(int)ImGuiCol.TableBorderStrong] = style.TableBorderStrongColor != default ? style.TableBorderStrongColor : currentStyle.Colors[(int)ImGuiCol.TableBorderStrong];
            currentStyle.Colors[(int)ImGuiCol.TableBorderLight] = style.TableBorderLightColor != default ? style.TableBorderLightColor : currentStyle.Colors[(int)ImGuiCol.TableBorderLight];
            currentStyle.Colors[(int)ImGuiCol.TableRowBg] = style.TableRowBgColor != default ? style.TableRowBgColor : currentStyle.Colors[(int)ImGuiCol.TableRowBg];
            currentStyle.Colors[(int)ImGuiCol.TableRowBgAlt] = style.TableRowBgAltColor != default ? style.TableRowBgAltColor : currentStyle.Colors[(int)ImGuiCol.TableRowBgAlt];
            currentStyle.Colors[(int)ImGuiCol.TextLink] = style.TextLinkColor != default ? style.TextLinkColor : currentStyle.Colors[(int)ImGuiCol.TextLink];
            currentStyle.Colors[(int)ImGuiCol.TextSelectedBg] = style.TextSelectedBgColor != default ? style.TextSelectedBgColor : currentStyle.Colors[(int)ImGuiCol.TextSelectedBg];
            currentStyle.Colors[(int)ImGuiCol.DragDropTarget] = style.DragDropTargetColor != default ? style.DragDropTargetColor : currentStyle.Colors[(int)ImGuiCol.DragDropTarget];
            currentStyle.Colors[(int)ImGuiCol.NavCursor] = style.NavCursorColor != default ? style.NavCursorColor : currentStyle.Colors[(int)ImGuiCol.NavCursor];
            currentStyle.Colors[(int)ImGuiCol.NavWindowingHighlight] = style.NavWindowingHighlightColor != default ? style.NavWindowingHighlightColor : currentStyle.Colors[(int)ImGuiCol.NavWindowingHighlight];
            currentStyle.Colors[(int)ImGuiCol.NavWindowingDimBg] = style.NavWindowingDimBgColor != default ? style.NavWindowingDimBgColor : currentStyle.Colors[(int)ImGuiCol.NavWindowingDimBg];
            currentStyle.Colors[(int)ImGuiCol.ModalWindowDimBg] = style.ModalWindowDimBgColor != default ? style.ModalWindowDimBgColor : currentStyle.Colors[(int)ImGuiCol.ModalWindowDimBg];
        }

        private unsafe void UpdateBuffers(ImDrawDataPtr drawData)
        {
            int totalVtxCount = drawData.TotalVtxCount;
            int totalIdxCount = drawData.TotalIdxCount;

            if (totalVtxCount == 0 || totalIdxCount == 0)
                return;

            int drawArgCount = 0;
            for (int n = 0; n < drawData.CmdListsCount; n++)
                drawArgCount += drawData.CmdLists[n].CmdBuffer.Size;

            _vertexBuffer?.Release();
            _vertexBuffer = new GraphicsBuffer(GraphicsBuffer.Target.Structured, totalVtxCount, UnsafeUtility.SizeOf<ImDrawVert>());
            _indexBuffer?.Release();
            _indexBuffer = new GraphicsBuffer(GraphicsBuffer.Target.Index, totalIdxCount, UnsafeUtility.SizeOf<ushort>());
            _argsBuffer?.Release();
            _argsBuffer = new GraphicsBuffer(GraphicsBuffer.Target.IndirectArguments, drawArgCount * 5, UnsafeUtility.SizeOf<int>());

            int vtxOffset = 0;
            int idxOffset = 0;
            int argsOffset = 0;

            NativeArray<int> drawArgs = new(5, Allocator.Temp);

            for (int n = 0; n < drawData.CmdListsCount; n++)
            {
                ImDrawListPtr cmdList = drawData.CmdLists[n];

                var vtxArray = NativeArrayUnsafeUtility.ConvertExistingDataToNativeArray<ImDrawVert>(
                    cmdList.VtxBuffer.Data, cmdList.VtxBuffer.Size, Allocator.None);
                var idxArray = NativeArrayUnsafeUtility.ConvertExistingDataToNativeArray<ushort>(
                    cmdList.IdxBuffer.Data, cmdList.IdxBuffer.Size, Allocator.None);

#if ENABLE_UNITY_COLLECTIONS_CHECKS
                NativeArrayUnsafeUtility.SetAtomicSafetyHandle(ref vtxArray, AtomicSafetyHandle.GetTempMemoryHandle());
                NativeArrayUnsafeUtility.SetAtomicSafetyHandle(ref idxArray, AtomicSafetyHandle.GetTempMemoryHandle());
#endif
                _vertexBuffer.SetData(vtxArray, 0, vtxOffset, vtxArray.Length);
                _indexBuffer.SetData(idxArray, 0, idxOffset, idxArray.Length);

                drawArgs[1] = 1;
                drawArgs[3] = vtxOffset;
                drawArgs[4] = 0;

                for (int i = 0; i < cmdList.CmdBuffer.Size; i++)
                {
                    var cmd = cmdList.CmdBuffer[i];
                    drawArgs[0] = (int)cmd.ElemCount;
                    drawArgs[2] = idxOffset + (int)cmd.IdxOffset;

                    _argsBuffer.SetData(drawArgs, 0, argsOffset, 5);
                    argsOffset += 5;
                }

                vtxOffset += vtxArray.Length;
                idxOffset += idxArray.Length;
            }
        }

        private unsafe void UpdateTexture(ImTextureDataPtr tex)
        {
            if (tex.Status == ImTextureStatus.WantCreate)
            {
                var unityTexture = new Texture2D(tex.Width, tex.Height, TextureFormat.RGBA32, false, true);
                unityTexture.filterMode = FilterMode.Bilinear;
                unityTexture.wrapMode = TextureWrapMode.Clamp;
                unityTexture.anisoLevel = 1;
#if UNITY_EDITOR
                unityTexture.hideFlags = HideFlags.HideAndDontSave;
#endif

                var pixels = tex.GetPixels();
                byte[] data = new byte[tex.Width * tex.Height * tex.BytesPerPixel];
                Marshal.Copy((IntPtr)pixels, data, 0, data.Length);

                unityTexture.LoadRawTextureData(data);
                unityTexture.Apply(false);

                tex.SetTexID(new ImTextureID(unityTexture.GetInstanceID()));
                tex.SetStatus(ImTextureStatus.Ok);
            }
            else if (tex.Status == ImTextureStatus.WantUpdates)
            {
                var unityTexture = Resources.InstanceIDToObject((int)tex.TexID.Handle) as Texture2D;
                if (unityTexture != null)
                {
                    var updates = tex.Updates;
                    for (int i = 0; i < updates.Size; i++)
                    {
                        var r = updates[i];

                        int srcPitch = r.W * tex.BytesPerPixel;
                        byte[] regionData = new byte[r.H * srcPitch];

                        for (int y = 0; y < r.H; y++)
                        {
                            var rowPixels = tex.GetPixelsAt(r.X, r.Y + y);
                            Marshal.Copy((IntPtr)rowPixels, regionData, y * srcPitch, srcPitch);
                        }

                        var colors = new Color32[r.W * r.H];
                        for (int j = 0; j < colors.Length; j++)
                        {
                            int idx = j * 4;
                            colors[j] = new Color32(
                                regionData[idx],
                                regionData[idx + 1],
                                regionData[idx + 2],
                                regionData[idx + 3]
                            );
                        }

                        unityTexture.SetPixels32(r.X, r.Y, r.W, r.H, colors);
                    }

                    unityTexture.Apply(false);
                    tex.SetStatus(ImTextureStatus.Ok);
                }
            }
            else if (tex.Status == ImTextureStatus.WantDestroy && tex.UnusedFrames > 0)
            {
                var unityTexture = Resources.InstanceIDToObject((int)tex.TexID.Handle) as Texture2D;
                if (unityTexture != null)
                {
                    UnityEngine.Object.DestroyImmediate(unityTexture);
                }

                tex.SetTexID(new ImTextureID(0));
                tex.SetStatus(ImTextureStatus.Destroyed);
            }
        }

        private void RenderImGuiDrawData(ImDrawDataPtr drawData)
        {
            UpdateBuffers(drawData);

            if (drawData.Textures.Size > 0)
            {
                for (int i = 0; i < drawData.Textures.Size; i++)
                {
                    var tex = drawData.Textures[i];
                    if (tex.Status != ImTextureStatus.Ok)
                    {
                        UpdateTexture(tex);
                    }
                }
            }

            _cmd.Clear();
            _cmd.SetRenderTarget(_renderTexture);
            _cmd.ClearRenderTarget(true, true, new Color(0, 0, 0, 0));

            Vector2 fbSize = drawData.DisplaySize;
            Vector2 fbScale = drawData.FramebufferScale;
            int fbWidth = Mathf.RoundToInt(fbSize.x * fbScale.x);
            int fbHeight = Mathf.RoundToInt(fbSize.y * fbScale.y);

            _cmd.SetViewport(new Rect(0, 0, fbWidth, fbHeight));
            _cmd.SetViewProjectionMatrices(Matrix4x4.identity, Matrix4x4.Ortho(0f, fbSize.x, fbSize.y, 0f, 0f, 1f));

            _material.SetBuffer(_vertexProperty, _vertexBuffer);

            Vector2 clipOff = drawData.DisplayPos;
            Vector2 clipScale = drawData.FramebufferScale;

            int vtxOffset = 0;
            int argOffset = 0;

            for (int n = 0; n < drawData.CmdListsCount; n++)
            {
                ImDrawListPtr drawList = drawData.CmdLists[n];

                for (int i = 0; i < drawList.CmdBuffer.Size; i++, argOffset += 5 * 4)
                {
                    var drawCmd = drawList.CmdBuffer[i];

                    Vector2 clipMin = new(
                        (drawCmd.ClipRect.x - clipOff.x) * clipScale.x,
                        (drawCmd.ClipRect.y - clipOff.y) * clipScale.y
                    );
                    Vector2 clipMax = new(
                        (drawCmd.ClipRect.z - clipOff.x) * clipScale.x,
                        (drawCmd.ClipRect.w - clipOff.y) * clipScale.y
                    );

                    if (clipMax.x <= clipMin.x || clipMax.y <= clipMin.y)
                        continue;

                    var texture = Resources.InstanceIDToObject((int)drawCmd.GetTexID().Handle) as Texture;
                    _materialPropertyBlock.SetTexture(_textureProperty, texture);
                    _materialPropertyBlock.SetInt(_baseVertexProperty, vtxOffset + (int)drawCmd.VtxOffset);

                    Rect scissorRect = new(
                        clipMin.x,
                        fbHeight - clipMax.y,
                        clipMax.x - clipMin.x,
                        clipMax.y - clipMin.y
                    );

                    _cmd.EnableScissorRect(scissorRect);
                    _cmd.DrawProceduralIndirect(_indexBuffer, Matrix4x4.identity, _material, 0, MeshTopology.Triangles, _argsBuffer, argOffset, _materialPropertyBlock);
                }

                vtxOffset += drawList.VtxBuffer.Size;
            }

            _cmd.DisableScissorRect();
            Graphics.ExecuteCommandBuffer(_cmd);
        }

        /// <summary>
        /// Disposes of the renderer resources.
        /// </summary>
        public void Dispose()
        {
            try
            {
                //* Release command buffer  
                _cmd?.Release();
                _cmd = null;

                //* Release graphics buffers
                _vertexBuffer?.Release();
                _indexBuffer?.Release();
                _argsBuffer?.Release();
                _vertexBuffer = null;
                _indexBuffer = null;
                _argsBuffer = null;

                //* Release material
                if (_material != null)
                {
                    UnityEngine.Object.DestroyImmediate(_material);
                    _material = null;
                }

                //* Release render texture
                if (_renderTexture != null)
                {
                    _renderTexture.Release();
                    UnityEngine.Object.DestroyImmediate(_renderTexture);
                    _renderTexture = null;
                }

                //* Release ImPlot context
                ImPlot.SetCurrentContext(null);
                ImPlot.SetImGuiContext(null);
                ImPlot.DestroyContext(_imPlotContext);
                _imPlotContext = null;

                //* Release ImNodes context
                ImNodes.SetCurrentContext(null);
                ImNodes.SetImGuiContext(null);
                ImNodes.DestroyContext(_imNodesContext);
                _imNodesContext = null;

                //* Release ImGuizmo context
                ImGuizmo.SetImGuiContext(null);

                //* Release ImGui context
                ImGui.SetCurrentContext(null);
                ImGui.DestroyContext(_imGuiContext);
                _imGuiContext = null;
            }
            catch (Exception e)
            {
                Debug.LogError($"Error disposing of ImGui renderer: {e.Message}\n{e.StackTrace}");
            }
            finally
            {
                GC.SuppressFinalize(this);
            }
        }
    }
}
