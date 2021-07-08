using UnityEngine;

namespace JasonStorey
{
    public static class ColorExtensions
    {
        public static string ToHex(this Color color) => 
            $"#{ColorUtility.ToHtmlStringRGBA(color)}";
        
        public static Color WithAlphaAt(this Color col,float a) => 
            new Color(col.r, col.g, col.b, a);
    }
}