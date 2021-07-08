using UnityEngine;
namespace JasonStorey
{
    /// <summary>
    /// Maps a range between two float ranges
    /// if you do not provide the target range it defaults to 0-1 to make
    /// interpolation easier.
    /// </summary>
    public class MapARange : MonoBehaviour
    {
        [SerializeField]
        float value = 10;

        [SerializeField]
        float rangeStart;
        [SerializeField]
        float rangeEnd;
        
        [SerializeField,Range(0,1)]
        float result;

        void OnValidate() => Check();
        void Start() => PrintResult();

        void Check() => result = value.Map(rangeStart,rangeEnd);
        void PrintResult() => print($"Mapping {value} between the range of ({rangeStart},{rangeEnd}) to (0,1) is {result}");
    }
}