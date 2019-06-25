using System.Collections.Generic;
using UnityEngine;

public static class MipMapTestTextureGenerator
{
    public static Texture2D Generate
    (IList<Color> colors, int textureSize = 1024, TextureFormat format = TextureFormat.RGB24)
    {
        const bool ENABLE_MIP_CHAIN = true;

        Texture2D texture = new Texture2D(textureSize, textureSize, format, ENABLE_MIP_CHAIN);

        Color color = colors[0];

        for (int i = 0; i <= 12; i++)
        {
            color = i < colors.Count ? colors[i] : color;
            FillMipMap(texture, i, color);

            textureSize = textureSize / 2;

            if (textureSize < 1)
            {
                break;
            }
        }

        texture.Apply(false);

        return texture;
    }

    private static void FillMipMap(Texture2D texture, int mipLevel, Color color)
    {
        Color[] pixels = texture.GetPixels(mipLevel);

        for (int i = 0; i < pixels.Length; i++)
        {
            pixels[i] = color;
        }

        texture.SetPixels(pixels, mipLevel);
    }
}