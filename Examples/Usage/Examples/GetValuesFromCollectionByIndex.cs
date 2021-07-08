using UnityEngine;
namespace JasonStorey
{
    public class GetValuesFromCollectionByIndex : MonoBehaviour
    {
        [SerializeField]
        string[] animals;

        [SerializeField]
        int[] indexes;

        void Start() => PrintResults();

        void PrintResults()
        {
            print($"<color=yellow>{name}</color>");
            print("Clamped");
            foreach (var index in indexes) 
                PrintClamped(index);
            
            print("Wrapped");
            foreach (var index in indexes) 
                PrintWrapped(index);
        }

        void PrintWrapped(int index)
        {
            var result = animals.GetElementAtWrapped(index);
            print($"{result} is the {index}th element (when wrapped to the collection size of {animals.Length})");
        }
        
        void PrintClamped(int index)
        {
            var result = animals.GetElementAtClamped(index);
            print($"{result} is the {index}th element (when clamped to the collection size of {animals.Length})");
        }
        
    }
}