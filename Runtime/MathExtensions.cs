using UnityEngine;

namespace JasonStorey
{
    public static class MathExtensions
    {
        public static float Map (this float value, float a, float b, float a1 = 0, float b2 = 1) => 
            (value - a) / (b - a) * (b2 - a1) + a1;

        public static float Map(this float value, Vector2 from, Vector2 to) =>
            value.Map(from.x, from.y, to.x, to.y);
    }
}