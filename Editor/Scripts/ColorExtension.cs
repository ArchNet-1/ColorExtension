using ArchNet.Library.Color;
using ArchNet.Library.Enum;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ArchNet.Extension.Color
{
    /// <summary>
    /// [EXTENSION] - [ARCH NET] - [COLOR] Extension color
    /// author : LOUIS PAKEL
    /// </summary>s
    [System.Serializable]
    public class ColorExtension : MonoBehaviour
    {
        #region Publics Fields

        public enum keyType
        {
            ENUM,
            INT
        }

        public EnumLibrary _enumLibrary;

        public keyType _keyType;

        public ColorLibrary _colorLibrary;

        public string _enumChoice;

        public int _enumIndex = 0;

        public Color32 _color;

        #endregion

        #region Public Methods

        /// <summary>
        /// Description : Load Color from enum choice
        /// </summary>
        public void LoadColor()
        {
            _color = _colorLibrary.GetColor(_enumIndex);
        }

        public string GetEnumName()
        {
            return _enumLibrary.GetEnumName(_enumIndex);
        }


        public void OnValidate()
        {
            gameObject.GetComponent<Image>().color = new Color32(_color.r, _color.g, _color.b, _color.a);
        }

        public void Start()
        {
            gameObject.GetComponent<Image>().color = new Color32(_color.r, _color.g, _color.b, _color.a);
        }

        #endregion
    }
}
