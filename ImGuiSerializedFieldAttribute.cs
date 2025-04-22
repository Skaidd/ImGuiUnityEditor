using System;

namespace ImGuiUnityEditor
{
    /// <summary>
    /// Allows you to mark fields that should be serialized by ImGuiUnityEditor
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public class ImGuiSerializedFieldAttribute : Attribute { }
}