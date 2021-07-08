using System;
using UnityEngine;
using Random = System.Random;

namespace JasonStorey
{
    public class DisplayDatesAsFriendlyStrings : MonoBehaviour
    {
        void Start() => PrintResult();

        void PrintResult()
        {
            for (int i = 0; i < 50; i++) 
                PrintDate(RandomDay);
        }
        
        void PrintDate(DateTimeOffset date) => 
            print($"Date: {date:D} ({date.ToFriendlyDuration()})");

        DateTime RandomDay
        {
            get
            {
                var start = new DateTime(1995, 1, 1);
                var range = (DateTime.Today - start).Days;
                return start.AddDays(_random.Next(range));
            }
        }
        static readonly Random _random = new Random();
    }
}