using System;

namespace ImGuiUnityEditor
{
    /// <summary>
    /// Allows you to add a menu item for IImGuiObjects
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class ImGuiMenuAttribute : Attribute
    {
        public string ItemName { get; set; }
        public int Priority { get; set; }
        public string Shortcut { get; set; }

        public ImGuiMenuAttribute(string itemName = null, int priority = 100, string shortcut = null)
        {
            ItemName = itemName;
            Priority = priority;
            Shortcut = shortcut ?? string.Empty;
        }
    }
}

