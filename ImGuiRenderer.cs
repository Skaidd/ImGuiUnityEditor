using UnityEngine;
using System;
using System.Runtime.InteropServices;
using UnityEngine.Rendering;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Collections;
using UnityEditor;

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
        private readonly CommandBuffer _cmd;
        private Material _material;
        private Texture2D _fontTexture;
        private readonly MaterialPropertyBlock _materialPropertyBlock;
        private RenderTexture _renderTexture;

        // ImGui IO 
        public ImGuiIOPtr IO { get; private set; }

        // Input handler
        public ImGuiRendererInputHandler InputHandler { get; private set; }

        /// <summary>
        /// Initializes the ImGui renderer.
        /// </summary>
        /// <param name="initialSize">The initial size of the rendering surface.</param>
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

                //* Initialize IO
                IO = ImGui.GetIO();

                //* Set up ImGui Default configuration
                IO.BackendFlags |= ImGuiBackendFlags.RendererHasVtxOffset;
                IO.ConfigFlags |= ImGuiConfigFlags.NavEnableKeyboard;
                IO.ConfigFlags |= ImGuiConfigFlags.NavEnableGamepad;
                IO.ConfigFlags |= ImGuiConfigFlags.DockingEnable;
                IO.ConfigInputTextCursorBlink = true;

                //* Set Initial display size
                IO.DisplaySize = new(1, 1);

                //* Disable ImGui's automatic INI file handling and log file handling
                var io = ImGui.GetIO();
                io.IniFilename = (byte*)IntPtr.Zero;
                io.LogFilename = (byte*)IntPtr.Zero;

                //* Setup fonts
                SetupFonts();
            }
            catch (Exception e)
            {
                Debug.LogError($"Error initializing ImGui renderer: {e.Message}\n{e.StackTrace}");
                Dispose();
            }
        }

        /// <summary>
        /// Sets up the fonts.
        /// </summary>
        private unsafe void SetupFonts()
        {
            LoadAllFonts();
            CreateFontTexture();
        }

        /// <summary>
        /// Loads all fonts from the Assets folder.
        /// </summary>
        public unsafe void LoadAllFonts()
        {
            //* Add the default font first
            IO.Fonts.AddFontDefault();

            //* Load all fonts from the Assets folder
            var fontAssets = AssetDatabase.FindAssets("t:Font", new[] { "Assets" });
            foreach (var fontAsset in fontAssets)
            {
                var fontAssetPath = AssetDatabase.GUIDToAssetPath(fontAsset);
                var font = AssetDatabase.LoadAssetAtPath<Font>(fontAssetPath);   
                IO.Fonts.AddFontFromFileTTF(fontAssetPath, font.fontSize);
            }

            IO.Fonts.Build();
        }

        /// <summary>
        /// Creates the font texture used by ImGui.
        /// </summary>
        private unsafe void CreateFontTexture()
        {
            byte* pixels = null;
            int width = 0, height = 0, bytesPerPixel = 0;
            IO.Fonts.GetTexDataAsRGBA32(&pixels, &width, &height, &bytesPerPixel);

            _fontTexture = new Texture2D(width, height, TextureFormat.RGBA32, false, true);
            _fontTexture.filterMode = FilterMode.Bilinear;
            _fontTexture.wrapMode = TextureWrapMode.Clamp;
            _fontTexture.anisoLevel = 1;
#if UNITY_EDITOR
            _fontTexture.hideFlags = HideFlags.HideAndDontSave;
#endif

            byte[] data = new byte[width * height * bytesPerPixel];
            Marshal.Copy((IntPtr)pixels, data, 0, data.Length);

            _fontTexture.LoadRawTextureData(data);
            _fontTexture.Apply(true);

            IO.Fonts.SetTexID(new ImTextureID(_fontTexture.GetInstanceID()));

            IO.Fonts.ClearTexData();
        }

        /// <summary>
        /// Sets up the ImGui context.
        /// </summary>
        public void SetupContext()
        {
            ImGui.SetCurrentContext(_imGuiContext);
            ImPlot.SetCurrentContext(_imPlotContext);
            ImNodes.SetCurrentContext(_imNodesContext);
            
            ImPlot.SetImGuiContext(_imGuiContext);
            ImNodes.SetImGuiContext(_imGuiContext);
            ImGuizmo.SetImGuiContext(_imGuiContext);
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
        /// Resizes the ImGui display.
        /// </summary>
        /// <param name="size">The new size.</param>
        private void Resize(Vector2 size)
        {
            if (size.x >= 0 && size.y >= 0)
            {
#if UNITY_EDITOR
                float dpiScale = UnityEditor.EditorGUIUtility.pixelsPerPoint;
#else
                float dpiScale = Screen.dpi;
#endif
                IO.DisplaySize = size;
                IO.DisplayFramebufferScale = new Vector2(dpiScale, dpiScale);

                //Calculate physical size with DPI scaling
                int physicalWidth = Mathf.RoundToInt(size.x * dpiScale);
                int physicalHeight = Mathf.RoundToInt(size.y * dpiScale);

                // Check if render texture needs to be resized
                if (_renderTexture != null &&
                    (_renderTexture.width != physicalWidth || _renderTexture.height != physicalHeight))
                {
                    // Release old texture
                    _renderTexture.Release();

                    // Update dimensions using physical size
                    _renderTexture.width = Mathf.Max(1, physicalWidth);
                    _renderTexture.height = Mathf.Max(1, physicalHeight);

                    // Recreate with new size
                    _renderTexture.Create();
                }
            }
        }

        /// <summary>
        /// Begins a new ImGui frame.
        /// </summary>
        private void BeginFrame()
        {
#if UNITY_EDITOR
            double time = UnityEditor.EditorApplication.timeSinceStartup;
#else
            double time = Time.realtimeSinceStartup;
#endif
            double deltaTime = time - _lastTime;
            IO.DeltaTime = (float)deltaTime;
            _lastTime = time;

            ImGui.NewFrame();
            ImGuizmo.BeginFrame();

            InputHandler?.UpdateInput();
        }

        /// <summary>
        /// Ends the ImGui frame and renders the draw data.
        /// </summary>
        private RenderTexture EndFrame()
        {
            ImGui.Render();
            RenderImGuiDrawData(ImGui.GetDrawData());
            return _renderTexture;
        }

        /// <summary>
        /// Begins a new ImGui frame.
        /// </summary>
        /// <param name="size">The size of the ImGui display.</param>
        public void Begin(Vector2 size)
        {
            SetupContext();
            Resize(size);
            BeginFrame();
        }

        /// <summary>
        /// Ends the ImGui frame and renders the draw data.
        /// </summary>
        /// <returns>The render texture.</returns>
        public RenderTexture End()
        {
            return EndFrame();
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
        /// Updates the graphics buffers with the draw data.
        /// </summary>
        /// <param name="drawData">The draw data to update the buffers with.</param>
        private unsafe void UpdateBuffers(ImDrawDataPtr drawData)
        {
            int totalVtxCount = drawData.TotalVtxCount;
            int totalIdxCount = drawData.TotalIdxCount;

            // Early out if nothing to draw
            if (totalVtxCount == 0 || totalIdxCount == 0)
                return;

            // Count total number of draw commands for arguments buffer
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

                // Create native arrays from the ImDrawVert and index buffers (zero-copy)
                var vtxArray = NativeArrayUnsafeUtility.ConvertExistingDataToNativeArray<ImDrawVert>(
                    cmdList.VtxBuffer.Data, cmdList.VtxBuffer.Size, Allocator.None);
                var idxArray = NativeArrayUnsafeUtility.ConvertExistingDataToNativeArray<ushort>(
                    cmdList.IdxBuffer.Data, cmdList.IdxBuffer.Size, Allocator.None);

#if ENABLE_UNITY_COLLECTIONS_CHECKS
                NativeArrayUnsafeUtility.SetAtomicSafetyHandle(ref vtxArray, AtomicSafetyHandle.GetTempMemoryHandle());
                NativeArrayUnsafeUtility.SetAtomicSafetyHandle(ref idxArray, AtomicSafetyHandle.GetTempMemoryHandle());
#endif
                // Upload vertex/index data
                _vertexBuffer.SetData(vtxArray, 0, vtxOffset, vtxArray.Length);
                _indexBuffer.SetData(idxArray, 0, idxOffset, idxArray.Length);

                // Prepare arguments for DrawProceduralIndirect
                drawArgs[1] = 1;                           // instance count
                drawArgs[3] = vtxOffset;                   // base vertex location
                drawArgs[4] = 0;                           // base instance location

                // Process all draw commands in this list
                for (int i = 0; i < cmdList.CmdBuffer.Size; i++)
                {
                    var cmd = cmdList.CmdBuffer[i];
                    drawArgs[0] = (int)cmd.ElemCount;      // index count per instance
                    drawArgs[2] = idxOffset + (int)cmd.IdxOffset; // start index location

                    // Upload draw arguments
                    _argsBuffer.SetData(drawArgs, 0, argsOffset, 5);
                    argsOffset += 5;                       // 5 ints for each cmd
                }

                vtxOffset += vtxArray.Length;
                idxOffset += idxArray.Length;
            }
        }

        private void RenderImGuiDrawData(ImDrawDataPtr drawData)
        {
            UpdateBuffers(drawData);

            _cmd.Clear();
            _cmd.SetRenderTarget(_renderTexture);
            _cmd.ClearRenderTarget(true, true, new Color(0, 0, 0, 0));

            float dpiScale = IO.DisplayFramebufferScale.x;
            Vector2 fbSize = IO.DisplaySize;
            int width = Mathf.RoundToInt(fbSize.x * dpiScale);
            int height = Mathf.RoundToInt(fbSize.y * dpiScale);

            _cmd.SetViewport(new Rect(0, 0, width, height));
            _cmd.SetViewProjectionMatrices(Matrix4x4.identity, Matrix4x4.Ortho(0f, fbSize.x, fbSize.y, 0f, 0f, 1f));

            _material.SetBuffer(_vertexProperty, _vertexBuffer);

            Vector4 clipOffset = new(drawData.DisplayPos.x, drawData.DisplayPos.y, drawData.DisplayPos.x, drawData.DisplayPos.y);

            int vtxOffset = 0;
            int argOffset = 0;

            for (int n = 0; n < drawData.CmdListsCount; n++)
            {
                ImDrawListPtr drawList = drawData.CmdLists[n];

                for (int i = 0; i < drawList.CmdBuffer.Size; i++, argOffset += 5 * 4)
                {
                    var drawCmd = drawList.CmdBuffer[i];

                    Vector4 clipSize = drawCmd.ClipRect - clipOffset;

                    if (clipSize.x >= fbSize.x || clipSize.y >= fbSize.y || clipSize.z < 0f || clipSize.w < 0f)
                        continue;

                    var texture = Resources.InstanceIDToObject((int)drawCmd.TextureId.Handle) as Texture;
                    _materialPropertyBlock.SetTexture(_textureProperty, texture);
                    _materialPropertyBlock.SetInt(_baseVertexProperty, vtxOffset + (int)drawCmd.VtxOffset);

                    Rect scissorRect = new(
                        clipSize.x * dpiScale,
                        (fbSize.y - clipSize.w) * dpiScale,
                        (clipSize.z - clipSize.x) * dpiScale,
                        (clipSize.w - clipSize.y) * dpiScale
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

                //* Release graphics buffers
                _vertexBuffer?.Release();
                _indexBuffer?.Release();
                _argsBuffer?.Release();

                //* Release material
                if (_material != null)
                {
                    UnityEngine.Object.DestroyImmediate(_material);
                    _material = null;
                }

                //* Release font texture
                if (_fontTexture != null)
                {
                    UnityEngine.Object.DestroyImmediate(_fontTexture);
                    _fontTexture = null;
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

                //* Release ImNodes context
                ImNodes.SetCurrentContext(null);
                ImNodes.SetImGuiContext(null);
                ImNodes.DestroyContext(_imNodesContext);

                //* Release ImGuizmo context
                ImGuizmo.SetImGuiContext(null);

                //* Release ImGui context
                ImGui.SetCurrentContext(null);
                ImGui.DestroyContext(_imGuiContext);
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