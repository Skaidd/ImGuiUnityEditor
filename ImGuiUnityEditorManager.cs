using System;
using UnityEditor;

namespace ImGuiUnityEditor
{
    /// <summary>
    /// Main manager for ImGui integration in the editor
    /// </summary>
    [InitializeOnLoad]
    public class ImGuiUnityEditorManager
    {
        /// <summary>
        /// Opens/Shows an ImGui object
        /// </summary>
        /// <typeparam name="T">The type of ImGui object to open</typeparam>
        /// <returns>The instance of the object that was opened</returns>
        public static T Open<T>() where T : class, IImGuiObject
        {
            if (typeof(ImGuiEditorWindow).IsAssignableFrom(typeof(T)))
            {
                var window = EditorWindow.GetWindow(typeof(T));
                window.Show();
                return window as T;
            }
            else
            {
                throw new InvalidOperationException($"Type {typeof(T)} is not a valid ImGuiEditorWindow");
            }
        }

        /// <summary>
        /// Closes an ImGui object
        /// </summary>
        /// <typeparam name="T">The type of ImGui object to close</typeparam>
        public static void Close<T>() where T : class, IImGuiObject
        {
            if (typeof(ImGuiEditorWindow).IsAssignableFrom(typeof(T)))
            {
                var window = EditorWindow.GetWindow(typeof(T));
                window.Close();
            }
        }
    }
}