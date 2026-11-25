// ArchNet · Color Extension — inspector
// Shows the library's keys as a dropdown (enum names) and recolors the object right away.
// Docs: https://archnet-plateform.fr/#ColorExtension

using ArchNet.Library;
using ArchNet.Library.Editor;
using UnityEditor;
using UnityEngine;

namespace ArchNet.Extension.Editor
{
    [CustomEditor(typeof(ColorExtension))]
    public class ColorExtensionEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            SerializedProperty library = serializedObject.FindProperty("_library");
            SerializedProperty key = serializedObject.FindProperty("_key");

            EditorGUILayout.PropertyField(library, new GUIContent("Color Library"));
            if (library.objectReferenceValue is ColorLibrary colorLibrary)
            {
                key.intValue = KeyGUI.KeyField(new GUIContent("Color"), key.intValue, colorLibrary);
                if (!colorLibrary.Contains(key.intValue))
                    EditorGUILayout.HelpBox($"The library has no color for {colorLibrary.KeyLabel(key.intValue)}.", MessageType.Warning);
            }

            if (serializedObject.ApplyModifiedProperties()) ((ColorExtension)target).Apply();
        }
    }
}
