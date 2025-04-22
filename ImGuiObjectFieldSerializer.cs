using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace ImGuiUnityEditor
{
    /// <summary>
    /// Serializes and deserializes fields of objects using Odin Serializer
    /// </summary>
    internal class ImGuiObjectFieldSerializer
    {
        /// <summary>
        /// Binding flags for fields
        /// </summary>
        private static readonly BindingFlags FieldBindingFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;

        /// <summary>
        /// Wrapper class for serialized field data
        /// </summary>
        [Serializable]
        private class SerializedFieldWrapper
        {
            public string FieldName;
            public byte[] SerializedValue;
        }

        /// <summary>
        /// Container class for serialized fields
        /// </summary>
        [Serializable]
        private class SerializedFieldsContainer
        {
            public List<SerializedFieldWrapper> Fields = new();
        }

        /// <summary>
        /// Serializes a field of an object
        /// </summary>
        /// <param name="target"> The target object to serialize </param>
        /// <param name="field"> The field to serialize </param>
        /// <param name="container"> The container to add the serialized field to </param>
        private static void SerializeField(object target, FieldInfo field, SerializedFieldsContainer container)
        {
            try
            {
                var value = field.GetValue(target);
                if (value == null)
                    return;

                byte[] bytes = OdinSerializer.SerializationUtility.SerializeValue(
                    value,
                    OdinSerializer.DataFormat.Binary);

                container.Fields.Add(new SerializedFieldWrapper
                {
                    FieldName = field.Name,
                    SerializedValue = bytes
                });
            }
            catch (Exception ex)
            {
                Debug.LogError($"Failed to serialize field {field.Name}: {ex.Message}");
            }
        }

        /// <summary>
        /// Deserializes the serialized data and returns a container of serialized fields
        /// </summary>
        /// <param name="serializedData"> The serialized data to deserialize </param>
        /// <returns> The deserialized container of serialized fields </returns>
        private static SerializedFieldsContainer DeserializeContainer(string serializedData)
        {
            byte[] containerBytes = Convert.FromBase64String(serializedData);

            return OdinSerializer.SerializationUtility.DeserializeValue<SerializedFieldsContainer>(
                containerBytes,
                OdinSerializer.DataFormat.Binary);
        }

        /// <summary>
        /// Applies the deserialized fields to the target object
        /// </summary>
        /// <param name="container"> The container of deserialized fields </param>
        /// <param name="target"> The target object to apply the deserialized fields to </param>
        private static void ApplyDeserializedFields(SerializedFieldsContainer container, object target)
        {
            var targetType = target.GetType();

            var fieldsByName = targetType.GetFields(FieldBindingFlags)
                .Where(field => field.GetCustomAttribute<ImGuiSerializedFieldAttribute>() != null)
                .ToDictionary(f => f.Name);

            foreach (var fieldData in container.Fields)
            {
                if (fieldsByName.TryGetValue(fieldData.FieldName, out var field))
                {
                    ApplyFieldValue(field, fieldData, target);
                }
            }
        }

        /// <summary>
        /// Applies the value of a field to the target object
        /// </summary>
        /// <param name="field"> The field to apply the value to </param>
        /// <param name="fieldData"> The data of the field to apply </param>
        /// <param name="target"> The target object to apply the value to </param>
        private static void ApplyFieldValue(FieldInfo field, SerializedFieldWrapper fieldData, object target)
        {
            try
            {
                var value = OdinSerializer.SerializationUtility.DeserializeValue<object>(
                    fieldData.SerializedValue,
                    OdinSerializer.DataFormat.Binary);

                field.SetValue(target, value);
            }
            catch (Exception ex)
            {
                Debug.LogError($"Failed to deserialize field {fieldData.FieldName}: {ex.Message}");
            }
        }

        /// <summary>
        /// Serializes an object's fields to a string
        /// </summary>
        /// <param name="target"> The target object to serialize </param>
        /// <returns> The serialized data </returns>
        public static string SerializeFields(object target)
        {
            if (target == null)
                return null;

            var container = new SerializedFieldsContainer();
            var targetType = target.GetType();

            var fields = targetType.GetFields(FieldBindingFlags)
            .Where(field => field.GetCustomAttribute<ImGuiSerializedFieldAttribute>() != null);

            foreach (var field in fields)
            {
                SerializeField(target, field, container);
            }

            byte[] containerBytes = OdinSerializer.SerializationUtility.SerializeValue(
                container,
                OdinSerializer.DataFormat.Binary);

            return Convert.ToBase64String(containerBytes);
        }

        /// <summary>
        /// Deserializes the serialized data and applies it to the target object's fields
        /// </summary>
        /// <param name="serializedData"> The serialized data to deserialize </param>
        /// <param name="target"> The target object to apply the deserialized data to </param>
        public static void DeserializeFields(string serializedData, object target)
        {
            if (string.IsNullOrEmpty(serializedData) || target == null)
                return;

            try
            {
                var container = DeserializeContainer(serializedData);
                if (container == null || container.Fields == null || container.Fields.Count == 0)
                    return;

                ApplyDeserializedFields(container, target);
            }
            catch (Exception ex)
            {
                Debug.LogError($"Failed to deserialize data: {ex.Message}");
            }
        }

        /// <summary>
        /// Checks if the fields of the target object have changed
        /// </summary>
        /// <param name="target"> The target object to check </param>
        /// <param name="lastSerializedData"> The last serialized data of the target object </param>
        /// <returns> True if the fields have changed, false otherwise </returns>
        public static bool HaveFieldsChanged(object target, string lastSerializedData)
        {
            if (target == null)
                return false;

            if (string.IsNullOrEmpty(lastSerializedData))
                return true;

            var currentSerialized = SerializeFields(target);
            return currentSerialized != lastSerializedData;
        }
    }
}