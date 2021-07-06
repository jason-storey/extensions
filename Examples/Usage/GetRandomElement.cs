using System.Collections.Generic;
using UnityEngine;
namespace JasonStorey.examples
{
    /// <summary>
    /// Returns a random element from a collection
    /// </summary>
    public class GetRandomElement : MonoBehaviour
    {
        [SerializeField,Range(0,100)]
        int amountToGenerate = 100;
        [SerializeField] string[] names;
        [SerializeField] List<string> jobs;

        string RandomNpc => $"{names.GetRandom()} the {jobs.GetRandom()}";

        void Start()
        {
            foreach (var character in RandomCharacters())
                print(character);
        }

        IEnumerable<string> RandomCharacters()
        {
            for (int i = 0; i < amountToGenerate; i++)
                yield return RandomNpc;
        }
    }
}