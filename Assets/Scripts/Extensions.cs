using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace Extensions
{
    public static class MonoBehaviourExtensions
    {
        [Conditional("UNITY_EDITOR")]
        public static void AssertReference<T>(this MonoBehaviour monoBehaviour, T reference)
        {
            if (reference == null)
            {
                // Pause the editor directly since exceptions don't halt execution in the editor and can be missed
                Debug.Break();
                throw new System.NullReferenceException($"Reference of type {typeof(T)} is null in {monoBehaviour.name}");
            }
        }
    }

    public static class ScriptableObjectExtensions
    {
        [Conditional("UNITY_EDITOR")]
        public static void AssertReference<T>(this ScriptableObject scriptableObject, T reference)
        {
            if (reference == null)
            {
                // Pause the editor directly since exceptions don't halt execution in the editor and can be missed
                Debug.Break();
                throw new System.NullReferenceException($"Reference of type {typeof(T)} is null in {scriptableObject.name}");
            }
        }
    }
}
