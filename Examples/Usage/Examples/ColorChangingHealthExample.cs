using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace JasonStorey
{
    public class ColorChangingHealthExample : MonoBehaviour
    {

        [SerializeField]
        float MaxHealth = 120;
        [SerializeField]
        float currentHealth = 100;

        [SerializeField]
        Color[] colors;

        [SerializeField]
        bool reverse = true;
        
        void Start() => PrintResults();

        void PrintResults()
        {
            for (int i = 0; i < 10; i++)
            {
                Damage();
                PrintHealth();
            }
        }

        void Damage() => 
            currentHealth = Mathf.Clamp(currentHealth -  Random.Range(1, 22),0, MaxHealth);

        void PrintHealth()
        {
            var color = GetHealthColor();
            print($"<color={color.ToHex()}>{currentHealth}</color>");
        }
        
        Color GetHealthColor() => colors.GetElementAtPercent(currentHealth/MaxHealth,reverse);
        Color GetHealthColorAlternate() => colors.GetElementFromMap(currentHealth, MaxHealth);
    }
}