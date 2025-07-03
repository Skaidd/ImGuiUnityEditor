using UnityEngine;

namespace ImGuiUnityEditor
{
    public static class ImGuiExtensionMethods
    {
        /// <summary>
        /// Get the font with specified name
        /// </summary>
        /// <param name="io">The ImGui IO.</param>
        /// <param name="fontName">The name of the font to get.</param>
        /// <returns>The font.</returns>
        public static ImFontPtr GetFont(this ImFontAtlasPtr io, string fontName)
        {
            for (int i = 0; i < io.Fonts.Size; i++)
            {
                var font = io.Fonts[i];
                if (font.Name() == fontName)
                {
                    return font;
                }
            }
            Debug.LogError($"Font '{fontName}' not found");
            return io.Fonts[0];
        }
    
        /// <summary>
        /// Get the name of the font.
        /// </summary>
        /// <param name="font">The font to get the name of.</param>
        /// <returns>The name of the font.</returns>
        public static string Name(this ImFontPtr font)
        {
            string name = font.GetDebugNameS();
            int ttfIndex = name.IndexOf(".ttf");
            return ttfIndex >= 0 ? name[..ttfIndex] : name;
        }

        /// <summary>
        /// Get ImTextureRef from unity texture.
        /// </summary>
        /// <param name="texture">The texture to get the reference of.</param>
        /// <returns>The texture reference.</returns>
        public static ImTextureRef ImTextureRef(this Texture texture)
        {
            return new ImTextureRef
            {
                TexID = new ImTextureID(texture.GetInstanceID())
            };
        }
    }
}

