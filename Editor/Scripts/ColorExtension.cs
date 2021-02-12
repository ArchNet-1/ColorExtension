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
            int lIndex;

            if (_keyType == keyType.ENUM && _enumChoice != "")
            {
                Type lEnumType = _enumLibrary.GetEnum(_colorLibrary);

                lIndex = _enumLibrary.GetEnumValue(lEnumType, _enumChoice);
            }
            else
            {
                lIndex = _enumIndex;
            }

            while  (null ==_colorLibrary.GetColor(lIndex))
            {
                lIndex--;
                if(lIndex < 0)
                {
                    lIndex = 0;
                    break;
                }
            }

            _color = _colorLibrary.GetColor(lIndex);
        }

        public Type GetEnum()
        {
            return _enumLibrary.GetEnum(_colorLibrary);
        }

        public string GetEnumName()
        {
            return _enumLibrary.GetEnumName(_colorLibrary);
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
