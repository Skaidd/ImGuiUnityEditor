using System;
using System.Collections.Generic;
using UnityEngine;

namespace ImGuiUnityEditor
{
    /// <summary>
    /// Data for an ImGui object
    /// </summary>
    [Serializable]
    internal class ImGuiObjectData
    {
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public string ImGuiData { get; private set; }
        [field: SerializeField] public string FieldsData { get; private set; }

        public ImGuiObjectData(string name, string data = null)
        {
            Name = name;
            ImGuiData = data ?? string.Empty;
            FieldsData = string.Empty;
        }
        
        /// <summary>
        /// Saves the ImGui settings, object fields, and style
        /// </summary>
        public void Save(IImGuiObject imGuiObject)
        {
            ImGuiData = imGuiObject.Container.SaveSettings();
            FieldsData = ImGuiObjectFieldSerializer.SerializeFields(imGuiObject);
        }

        /// <summary>
        /// Loads the ImGui settings, object fields, and style
        /// </summary>
        public void Load(IImGuiObject imGuiObject)
        {
            if (!string.IsNullOrEmpty(ImGuiData))
                imGuiObject.Container.LoadSettings(ImGuiData);

            if (!string.IsNullOrEmpty(FieldsData))
                ImGuiObjectFieldSerializer.DeserializeFields(FieldsData, imGuiObject);
        }
    }
}