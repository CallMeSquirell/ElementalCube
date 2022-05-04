using UnityEngine;

namespace Framework.Extensions
{
    public static class ColorExtenstion
    {
        public static Color SetAlpha(this Color color, float value)
        {
            var newColor = color;
            newColor.a = value;
            return newColor;
        }
    }
}