using System;
using UnityEngine;
namespace JasonStorey
{
    public class GetValuesFromCollectionByPercent : MonoBehaviour
    {
        [SerializeField]
        string[] animals;

        [SerializeField]
        Percentage[] percentages;
        
        void Start() => PrintResults();

        void PrintResults()
        {
            print($"<color=yellow>{name}</color>");
            foreach (var percentage in percentages) 
                PrintPercent(percentage.value);
        }

        void PrintPercent(float percent)
        {
            var chosen = animals.GetElementAtPercent(percent);
            print($"{chosen} is the element at {percent*100}%");
        }
        
    }

    [Serializable]
    class Percentage
    {
        public float value = 0.3f;
    }
}