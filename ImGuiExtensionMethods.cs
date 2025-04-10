using UnityEngine;

namespace ImGuiUnityEditor
{
    public static class ImGuiExtensionMethods
    {
        /// <summary>
        /// Get the font
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
            string fn = font.GetDebugNameS();
            if (fn.Contains(",")) fn = fn[..fn.IndexOf(",")].Trim();
            if (fn.Contains(".")) fn = fn[..fn.LastIndexOf(".")];
            return fn;
        }
    }
}

