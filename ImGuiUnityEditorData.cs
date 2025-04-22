using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace ImGuiUnityEditor
{
    [FilePath("ImGuiEditor/ImGuiEditorData.asset", FilePathAttribute.Location.ProjectFolder)]
    internal class ImGuiUnityEditorData : ScriptableSingleton<ImGuiUnityEditorData>
    {
        [field: SerializeField] public List<ImGuiObjectData> ImGuiObjectData { get; set; } = new();

        private void OnEnable()
        {
            CleanupOldImGuiObjectData();
        }

        /// <summary>
        /// Cleans up old imgui object data
        /// </summary>
        private void CleanupOldImGuiObjectData()
        {
            var objectTypes = TypeCache.GetTypesDerivedFrom<IImGuiObject>();
            foreach (var objectData in ImGuiObjectData.ToArray())
            {
                if (!objectTypes.Any(type => type.Name == objectData.Name))
                {
                    ImGuiObjectData.Remove(objectData);
                }
            }
        }

        /// <summary>
        /// Gets or creates a imgui object data entry by name
        /// </summary>
        public ImGuiObjectData GetOrCreateObjectData(string name)
        {
            var data = ImGuiObjectData.FirstOrDefault(d => d.Name == name);
            if (data == null)
            {
                data = new ImGuiObjectData(name);
                ImGuiObjectData.Add(data);
            }
            return data;
        }

        /// <summary>
        /// Saves the imgui object data
        /// </summary>
        public void Save(IImGuiObject imGuiObject)
        {
            var objectData = GetOrCreateObjectData(imGuiObject.GetType().Name);
            objectData.Save(imGuiObject);
            Save(true);
        }

        /// <summary>
        /// Loads the imgui object data
        /// </summary>
        public void Load(IImGuiObject imGuiObject)
        {
            var objectData = GetOrCreateObjectData(imGuiObject.GetType().Name);
            objectData.Load(imGuiObject);
        }
    }
}