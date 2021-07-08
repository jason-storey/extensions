using UnityEngine;
namespace JasonStorey
{
    public class ValidatesMissingFields : MonoBehaviour
    {
        [SerializeField, Required]
        GameObject someObject;

        [SerializeField, Required]
        Texture someTexture;
    }
}