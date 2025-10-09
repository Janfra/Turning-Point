using UnityEngine;

namespace Extensions
{
    public static class MonoBehaviourExtensions
    {
        public static void AssertReference<T>(this MonoBehaviour monoBehaviour, T reference)
        {
            if (reference == null)
            {
                throw new System.NullReferenceException($"Reference of type {typeof(T)} is null in {monoBehaviour.name}");
            }
        }
    }
}
