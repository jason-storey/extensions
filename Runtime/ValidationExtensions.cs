using JasonStorey.JasonStorey;

namespace JasonStorey
{
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using Object = UnityEngine.Object;
namespace JasonStorey
{
    public static class ValidationExtensions
    {
        /// <summary>
        /// Validates if any of the required fields are missing
        /// </summary>
        /// <param name="obj"></param>
        /// <typeparam name="T"></typeparam>
        public static void Validate<T>(this T obj) where T : MonoBehaviour
        {
            var req = RequiredFields(obj);

            foreach (var rInfo in req)
            {
                var val = rInfo.GetValue(obj);
                switch (val)
                {
                    case Object unityObj  when !unityObj:
                    case null:
                        Debug.LogWarning($"Required <color=yellow>{rInfo.Name}</color> missing from {obj.name}", obj);
                        break;
                }
            }
        }
        
        /// <summary>
        /// Returns a list of required attributes on the provided behaviour
        /// </summary>
        /// <param name="obj"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        static IEnumerable<FieldInfo> RequiredFields<T>(T obj) where T : MonoBehaviour =>
            obj.GetType().GetFields(
                    BindingFlags.FlattenHierarchy |
                    BindingFlags.Instance |
                    BindingFlags.NonPublic |
                    BindingFlags.Public |
                    BindingFlags.Static)
                .Where(x=>x.GetCustomAttributes().Any(y=>y is RequiredAttribute));
    }
    

}

/// <summary>
/// Marks this field as Required
/// </summary>
[AttributeUsage(AttributeTargets.Field)]
public class RequiredAttribute : Attribute { }


#if UNITY_EDITOR
/// <summary>
/// Automatically runs on play in editor to check if any fields are missing
/// </summary>
public class CheckMissingFields 
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    static void TryValidate()
    {
        var behaviours = Object.FindObjectsOfType<MonoBehaviour>();
        foreach (var behaviour in behaviours) behaviour.Validate();
    }
}
#endif
}