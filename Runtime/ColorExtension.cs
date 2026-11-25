// ArchNet · Color Extension
// Colors a UI element (Image, Text…) or a SpriteRenderer from a Color Library key, so the
// palette lives in one asset. Change the key from code or pick it in the inspector.
// Docs: https://archnet-plateform.fr/#ColorExtension

using ArchNet.Library;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace ArchNet.Extension
{
    [ExecuteAlways]
    [AddComponentMenu("ArchNet/Library Color")]
    public class ColorExtension : MonoBehaviour
    {
        [FormerlySerializedAs("_colorLibrary")]
        [SerializeField] ColorLibrary _library;
        [FormerlySerializedAs("_enumIndex")]
        [SerializeField] int _key;

        public ColorLibrary Library { get => _library; set { _library = value; Apply(); } }

        /// <summary>The library key of the color; setting it recolors the object.</summary>
        public int Key { get => _key; set { _key = value; Apply(); } }

        /// <summary>Applies the color of the current key to the Graphic or SpriteRenderer on this object.</summary>
        public void Apply()
        {
            if (_library == null || !_library.TryGet(_key, out Color color)) return;
            if (TryGetComponent(out Graphic graphic)) graphic.color = color;
            else if (TryGetComponent(out SpriteRenderer sprite)) sprite.color = color;
        }

        void OnEnable() => Apply();
        void OnValidate() => Apply();
    }
}
