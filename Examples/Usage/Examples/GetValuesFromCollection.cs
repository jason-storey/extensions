using System;
using UnityEngine;
namespace JasonStorey
{
    public class GetValuesFromCollection : MonoBehaviour
    {
        [SerializeField]
        Loot[] loot;

        void Start() => PrintResults();

        void PrintResults()
        {
            var rarest = loot.MaxBy(x => x.Rarity);
            print($"The rarest item is the {rarest.Name}");
            
            var cheapest = loot.MinBy(x => x.Price);
            print($"The cheapest item is the {cheapest.Name}");
            
            print("If you print the array you get:");
            print(loot);
            print("but if you display the array you get:");
            print(loot.ToDisplayString());
        }
        
    }

    [Serializable]
    public class Loot
    {
        public string Name;
        public int Rarity;
        public int Price;

        public override string ToString() => $"{Name} ({Rarity}:{Price})";
    }
}