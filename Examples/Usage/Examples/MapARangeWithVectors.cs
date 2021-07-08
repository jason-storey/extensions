using System;
using UnityEngine;
namespace JasonStorey
{
    /// <summary>
    /// Maps a value between  range.
    /// For example if you want to map 0-1 to the screen with
    /// or map the distance from two value to a 0-1 for fading etc
    /// </summary>
    public class MapARangeWithVectors : MonoBehaviour
    {
        [SerializeField]
        float value = 10;
        
        [SerializeField]
        Vector2 From;
        [SerializeField]
        Vector2 To;

        [SerializeField]
        float result;

        void OnValidate() => Check();
        void Start() => PrintResult();
        
        void Check() => result = value.Map(From,To);
        void PrintResult() => print($"Mapping {value} between the range of {From} to {To} is {result}");
    }
}