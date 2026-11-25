<p align="center">
  <a href="https://archnet-plateform.fr"><img src="https://archnet-plateform.fr/ArchNetLogoWithBck.png" alt="ArchNet" width="240"></a>
</p>

# ArchNet · Color Extension

Colors a UI element or a SpriteRenderer from a Color Library key, so the palette lives in one asset.

- Unity **6000.0** or newer · Needs `com.archnet.library.color`, `com.archnet.library.core` (the ArchNet installer adds them for you).
- Part of [ArchNet](https://archnet-plateform.fr), free and open-source Unity packages

## Install

*Window > Package Manager > + > Install package from git URL…*

```
https://github.com/ArchNet-1/ColorExtension.git
```

## Use

Add **ArchNet > Library Color** to an object with an Image, Text or SpriteRenderer, pick the Color Library and the color. From code: `GetComponent<ColorExtension>().Key = (int)Theme.Accent;`

## License

See [LICENSE.md](LICENSE.md).
