using System;
using UnityEngine;

namespace ImGuiUnityEditor
{
    /// <summary>
    /// Utility class for rendering Unity objects with ImGui
    /// </summary>
    public static class ImGuiUnity
    {
        #region Methods

        /// <summary>
        /// Renders a Texture2D as an image in ImGui
        /// </summary>
        /// <param name="texture">The texture to render</param>
        /// <param name="size">The size to display the texture</param>
        /// <param name="uv0">The top-right UV coordinate (default is (1,1))</param>
        /// <param name="uv1">The bottom-left UV coordinate (default is (0,0))</param>
        public static void Image(Texture2D texture, Vector2 size, Vector2 uv0 = default, Vector2 uv1 = default)
        {
            if (texture != null)
            {
                ImGui.Image(texture.ImTextureRef(), new Vector2(size.x, size.y),
                uv0 == default ? new Vector2(1, 1) : uv0, uv1 == default ? new Vector2(0, 0) : uv1);
            }
            else
            {
                ImGui.TextColored(new(1, 0, 0, 1), "Texture is null");
            }
        }

        /// <summary>
        /// Renders a RenderTexture as an image in ImGui
        /// </summary>
        /// <param name="renderTexture">The render texture to display</param>
        /// <param name="size">The size to display the texture</param>
        /// <param name="uv0">The top-right UV coordinate (default is (1,1))</param>
        /// <param name="uv1">The bottom-left UV coordinate (default is (0,0))</param>
        public static void Image(RenderTexture renderTexture, Vector2 size, Vector2 uv0 = default, Vector2 uv1 = default)
        {
            if (renderTexture != null)
            {
                ImGui.ImageWithBg(renderTexture.ImTextureRef(), new Vector2(size.x, size.y),
                uv0 == default ? new Vector2(1, 1) : uv0, uv1 == default ? new Vector2(0, 0) : uv1);
            }
            else
            {
                ImGui.TextColored(new(1, 0, 0, 1), "RenderTexture is null");
            }
        }


        /// <summary>
        /// Renders a Sprite as an image in ImGui
        /// </summary>
        /// <param name="sprite">The sprite to render</param>
        /// <param name="size">The size to display the sprite</param>
        /// <param name="uv0">The top-right UV coordinate (default is (1,1))</param>
        /// <param name="uv1">The bottom-left UV coordinate (default is (0,0))</param>
        public static void Image(Sprite sprite, Vector2 size, Vector2 uv0 = default, Vector2 uv1 = default)
        {
            if (sprite != null)
            {
                ImGui.ImageWithBg(sprite.texture.ImTextureRef(), new Vector2(size.x, size.y),
                uv0 == default ? new Vector2(1, 1) : uv0, uv1 == default ? new Vector2(0, 0) : uv1);
            }
            else
            {
                ImGui.TextColored(new(1, 0, 0, 1), "Texture is null");
            }
        }

        /// <summary>
        /// Draws an image button using ImGui
        /// </summary>
        /// <param name="texture"> The texture to draw </param>
        /// <param name="size"> The size to display the texture </param>
        /// <param name="backgroundColor"> The background color of the button </param>
        /// <param name="tintColor"> The tint color of the button </param>
        public static void ImageButton(Texture2D texture, Vector2 size, Vector2 uv0 = default, Vector2 uv1 = default, Color backgroundColor = default, Color tintColor = default)
        {
            if (texture != null)
            {
                ImGui.ImageButton($"##{texture.name}_button",
                texture.ImTextureRef(), new Vector2(size.x, size.y),
                uv0 == default ? new Vector2(1, 1) : uv0, uv1 == default ? new Vector2(0, 0) : uv1,
                backgroundColor == default ? Color.black : backgroundColor,
                tintColor == default ? Color.white : tintColor);
            }
            else
            {
                ImGui.TextColored(new(1, 0, 0, 1), "Texture is null");
            }
        }


        /// <summary>
        /// Draws an image button using ImGui
        /// </summary>
        /// <param name="texture"> The texture to draw </param>
        /// <param name="size"> The size to display the texture </param>
        /// <param name="backgroundColor"> The background color of the button </param>
        /// <param name="tintColor"> The tint color of the button </param>
        public static void ImageButton(RenderTexture renderTexture, Vector2 size, Vector2 uv0 = default, Vector2 uv1 = default, Color backgroundColor = default, Color tintColor = default)
        {
            if (renderTexture != null)
            {
                ImGui.ImageButton($"##{renderTexture.name}_button",
                renderTexture.ImTextureRef(), new Vector2(size.x, size.y),
                uv0 == default ? new Vector2(1, 1) : uv0, uv1 == default ? new Vector2(0, 0) : uv1,
                backgroundColor == default ? Color.black : backgroundColor,
                tintColor == default ? Color.white : tintColor);
            }
            else
            {
                ImGui.TextColored(new(1, 0, 0, 1), "RenderTexture is null");
            }
        }

        /// <summary>
        /// Draws an image button using ImGui
        /// </summary>
        /// <param name="texture"> The texture to draw </param>
        /// <param name="size"> The size to display the texture </param>
        /// <param name="uv0"> The top-right UV coordinate (default is (1,1)) </param>
        /// <param name="uv1"> The bottom-left UV coordinate (default is (0,0)) </param>
        /// <param name="backgroundColor"> The background color of the button </param>
        /// <param name="tintColor"> The tint color of the button </param>
        public static void ImageButton(Sprite sprite, Vector2 size, Vector2 uv0 = default, Vector2 uv1 = default, Color backgroundColor = default, Color tintColor = default)
        {
            if (sprite != null)
            {
                ImGui.ImageButton($"##{sprite.name}_button",
                sprite.texture.ImTextureRef(), new Vector2(size.x, size.y),
                uv0 == default ? new Vector2(1, 1) : uv0, uv1 == default ? new Vector2(0, 0) : uv1,
                backgroundColor == default ? Color.black : backgroundColor,
                tintColor == default ? Color.white : tintColor);
            }
            else
            {
                ImGui.TextColored(new(1, 0, 0, 1), "Sprite is null");
            }
        }
        
        #endregion

        #region Extension Methods

        /// <summary>
        /// Renders a Texture2D using ImGui
        /// </summary>
        /// <param name="texture">The texture to render</param>
        /// <param name="size">The size to display the texture</param>
        /// <param name="uv0">The top-right UV coordinate (default is (1,1))</param>
        /// <param name="uv1">The bottom-left UV coordinate (default is (0,0))</param>
        public static void ImGuiImage(this Texture2D texture, Vector2 size, Vector2 uv0 = default, Vector2 uv1 = default)
        {
            ImGuiUnity.Image(texture, size, uv0, uv1);
        }

        /// <summary>
        /// Renders a RenderTexture using ImGui
        /// </summary>
        /// <param name="renderTexture">The render texture to display</param>
        /// <param name="size">The size to display the texture</param>
        /// <param name="uv0">The top-right UV coordinate (default is (1,1))</param>
        /// <param name="uv1">The bottom-left UV coordinate (default is (0,0))</param>
        public static void ImGuiImage(this RenderTexture renderTexture, Vector2 size, Vector2 uv0 = default, Vector2 uv1 = default)
        {
            ImGuiUnity.Image(renderTexture, size, uv0, uv1);
        }

        /// <summary>
        /// Renders a Sprite using ImGui
        /// </summary>
        /// <param name="sprite">The sprite to render</param>
        /// <param name="size">The size to display the sprite</param>
        /// <param name="uv0">The top-right UV coordinate (default is (1,1))</param>
        /// <param name="uv1">The bottom-left UV coordinate (default is (0,0))</param>
        public static void ImGuiSprite(this Sprite sprite, Vector2 size, Vector2 uv0 = default, Vector2 uv1 = default)
        {
            ImGuiUnity.Image(sprite, size, uv0, uv1);
        }

        /// <summary>
        /// Draws an image button using ImGui
        /// </summary>
        /// <param name="texture"> The texture to draw </param>
        /// <param name="size"> The size to display the texture </param>
        /// <param name="uv0"> The top-right UV coordinate (default is (1,1)) </param>
        /// <param name="uv1"> The bottom-left UV coordinate (default is (0,0)) </param>
        /// <param name="tintCol"> The tint color of the button </param>
        /// <param name="borderCol"> The border color of the button </param>
        public static void ImGuiButton(this Texture2D texture, Vector2 size, Vector2 uv0 = default, Vector2 uv1 = default, Vector4 tintCol = default, Vector4 borderCol = default)
        {
            ImGuiUnity.ImageButton(texture, size, uv0, uv1, tintCol, borderCol);
        }

        /// <summary>
        /// Draws an image button using ImGui
        /// </summary>
        /// <param name="renderTexture"> The render texture to draw </param>
        /// <param name="size"> The size to display the render texture </param>
        /// <param name="uv0"> The top-right UV coordinate (default is (1,1)) </param>
        /// <param name="uv1"> The bottom-left UV coordinate (default is (0,0)) </param>
        /// <param name="tintCol"> The tint color of the button </param>  
        /// <param name="borderCol"> The border color of the button </param>
        public static void ImGuiButton(this RenderTexture renderTexture, Vector2 size, Vector2 uv0 = default, Vector2 uv1 = default, Vector4 tintCol = default, Vector4 borderCol = default)
        {
            ImGuiUnity.ImageButton(renderTexture, size, uv0, uv1, tintCol, borderCol);
        }

        /// <summary>
        /// Draws an image button using ImGui
        /// </summary>
        /// <param name="sprite"> The sprite to draw </param>
        /// <param name="size"> The size to display the sprite </param>
        /// <param name="uv0"> The top-right UV coordinate (default is (1,1)) </param>
        /// <param name="uv1"> The bottom-left UV coordinate (default is (0,0)) </param>
        /// <param name="tintCol"> The tint color of the button </param>
        /// <param name="borderCol"> The border color of the button </param>
        public static void ImGuiButton(this Sprite sprite, Vector2 size, Vector2 uv0 = default, Vector2 uv1 = default, Vector4 tintCol = default, Vector4 borderCol = default)
        {
            ImGuiUnity.ImageButton(sprite, size, uv0, uv1, tintCol, borderCol);
        }

        #endregion
    }
}