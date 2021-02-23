using ArchNet.Library.Colors;
using ArchNet.Library.Enum;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static ArchNet.Extension.Color.ColorExtension;

namespace ArchNet.Extension.Color.Editor
{
    /// <summary>
    /// Description : Load a color from a color Library inside a Image
    /// @Author : Louis PAKEL
    /// </summary>
    [CustomEditor(typeof(ColorExtension))]
    public class ColorExtensionEditor : UnityEditor.Editor
    {
        #region Private Fields
        private List<string> _keyChoices = new List<string>();
        private List<string> _enumChoices = new List<string>();

        private ColorExtension _manager = null;

        private GUIStyle _warningInfos = null;

        private SerializedProperty _enumLibrary = null;
        private SerializedProperty _colorLibrary = null;
        private SerializedProperty _keyType = null;
        private SerializedProperty _enumIndex = null;
        private SerializedProperty _enumChoice = null;

        #endregion

        #region Unity Methods
        private void OnEnable()
        {
            _warningInfos = new GUIStyle();
            _warningInfos.normal.textColor = UnityEngine.Color.red;
            _warningInfos.fontStyle = FontStyle.Bold;

            _keyChoices.Add("Enum");
            _keyChoices.Add("Int");

            _manager = target as ColorExtension;
        }

        private void OnDisable()
        {
            _manager = null;
            _warningInfos = null;
        }



        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.LabelField("COLOR EXTENSION");
            EditorGUILayout.LabelField("This extension can allow to get a color from an Color Library");

            _enumLibrary = serializedObject.FindProperty("_enumLibrary");
            _colorLibrary = serializedObject.FindProperty("_colorLibrary");
            _keyType = serializedObject.FindProperty("_keyType");
            _enumIndex = serializedObject.FindProperty("_enumIndex");
            _enumChoice = serializedObject.FindProperty("_enumChoice");

            EditorGUILayout.Space(10);

            DisplaySpriteData();

            // Sprite Data is set
            if (true == IsConditionsOK())
            {
                EnumLibrary lEnumLibrary = (EnumLibrary)_enumLibrary.objectReferenceValue;
                ColorLibrary lColorLibrary = (ColorLibrary)_colorLibrary.objectReferenceValue;

                if (true == lEnumLibrary.IsExist(lColorLibrary))
                {
                    EditorGUILayout.BeginHorizontal();

                    DisplayEnum();

                    EditorGUILayout.EndHorizontal();
                }
                else
                {
                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.LabelField("This library is not in the enum library, please verify your data", _warningInfos);
                    EditorGUILayout.EndHorizontal();
                }
            }

            EditorGUILayout.Space(10);

            // Apply modifications
            serializedObject.ApplyModifiedProperties();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Description : Display Color Data Values
        /// </summary>
        private void DisplaySpriteData()
        {
            EditorGUILayout.BeginHorizontal();

            _keyType.intValue = EditorGUILayout.Popup(_keyType.intValue, _keyChoices.ToArray());
            _manager._keyType = (keyType)_keyType.intValue;

            EditorGUILayout.Space(15);
            EditorGUILayout.EndHorizontal();

            if (_manager._keyType == keyType.ENUM)
            {
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField("Enum Library");

                _enumLibrary.objectReferenceValue = (EnumLibrary)EditorGUILayout.ObjectField(_enumLibrary.objectReferenceValue, typeof(EnumLibrary), true);

                EditorGUILayout.EndHorizontal();
            }

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Color Library");

            _colorLibrary.objectReferenceValue = (ColorLibrary)EditorGUILayout.ObjectField(_colorLibrary.objectReferenceValue, typeof(ColorLibrary), true);

            EditorGUILayout.EndHorizontal();
            EditorGUILayout.Space(5);


            _manager._enumLibrary = (EnumLibrary)_enumLibrary.objectReferenceValue;
            _manager._colorLibrary = (ColorLibrary)_colorLibrary.objectReferenceValue;
        }

        /// <summary>
        /// Description : Display Enum Value
        /// </summary>
        private void DisplayEnum()
        {
            EditorGUILayout.BeginVertical();
            EditorGUILayout.Space(10);

            if (_manager._keyType == keyType.INT)
            {
                EditorGUILayout.LabelField("Int Value");
                EditorGUILayout.Space(5);

                _enumIndex.intValue = EditorGUILayout.IntField(_manager._enumIndex);

                _manager._enumIndex = _enumIndex.intValue;

                _manager.LoadColor();
            }
            else if (_manager._keyType == keyType.ENUM)
            {
                EditorGUILayout.LabelField("Enum Value");
                EditorGUILayout.Space(5);

                _enumChoice.stringValue = _manager.GetEnumName();

                if (_enumChoice.stringValue != "")
                {
                    _enumChoices = _manager._enumLibrary.GetEnumKeys(_enumChoice.stringValue);

                    _enumIndex.intValue = EditorGUILayout.Popup(_manager._enumIndex, _enumChoices.ToArray());

                    _manager._enumIndex = _enumIndex.intValue;

                    // Set enum string value
                    _manager._enumChoice = _enumChoices[_enumIndex.intValue];

                    _manager.LoadColor();
                }
                else
                {
                    EditorGUILayout.LabelField("Color Library doesnt have an enum");
                }
            }

            EditorGUILayout.EndVertical();

            EditorGUILayout.Space(5);
        }



        /// <summary>
        /// Description : check if every condition are respected
        /// </summary>
        /// <returns></returns>
        private bool IsConditionsOK()
        {
            if (_colorLibrary == null || (_enumLibrary == null && _manager._keyType == keyType.ENUM))
            {
                return false;
            }

            if (_colorLibrary.objectReferenceValue == null || (_enumLibrary.objectReferenceValue == null && _manager._keyType == keyType.ENUM))
            {
                return false;
            }

            if (_manager._colorLibrary == null || (_manager._enumLibrary == null && _manager._keyType == keyType.ENUM))
            {
                return false;
            }

            return true;
        }


        #endregion

    }
}
