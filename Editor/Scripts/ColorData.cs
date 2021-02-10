using UnityEngine;
using UnityEngine.UI;

namespace ArchNet.Extension.Color
{
    /// <summary>
    /// Description : Color data to store non persistent 
    /// </summary>
    public class ColorData : MonoBehaviour
    {
        #region Private Field

        private ColorExtension _colorExtension = null;

        private Image _image = null;

        #endregion

        #region Private Fields

        private int _index = 0;

        #endregion

        #region Unity Methods

        private void Start()
        {
            OnValidate();
        }

        public void OnValidate()
        {
            if(IsInit() == false)
            {
                Init();
            }

            if (IsUpdate() == false)
            {
                UpdateDatas();
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Description : init the color data
        /// </summary>
        /// <returns></returns>
        private void Init()
        {
            if (gameObject.GetComponent<ColorExtension>() == null)
            {
                gameObject.AddComponent<ColorExtension>();
            }

            if (gameObject.GetComponent<Image>() == null)
            {
                gameObject.AddComponent<Image>();
            }

            _image = gameObject.GetComponent<Image>();

            // Set ColorExtension
            _colorExtension = gameObject.GetComponent<ColorExtension>();
        }


        /// <summary>
        /// Description : Update Image source
        /// </summary>
        private void UpdateDatas()
        {
            _colorExtension = gameObject.GetComponent<ColorExtension>();

            _index = _colorExtension._enumIndex;

            Color32 lColor = _colorExtension._colorLibrary.GetColor(_index);

            _image.color = new Color32(lColor.r, lColor.g, lColor.g, lColor.a);
        }

        /// <summary>
        /// Description : Color Data need update
        /// </summary>
        /// <returns></returns>
        private bool IsUpdate()
        {
            bool lResult = true;

            if (_colorExtension._enumIndex != _index)
            {
                lResult = false;
            }

            return lResult;
        }


        /// <summary>
        /// Description : check if the color data is init
        /// </summary>
        /// <returns></returns>
        private bool IsInit()
        {
            bool lResult = true;

            if(_colorExtension == null || _image == null)
            {
                lResult = false;
            }

            return lResult;
        }

        #endregion
    }
}
