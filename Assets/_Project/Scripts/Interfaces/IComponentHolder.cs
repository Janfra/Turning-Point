using UnityEngine;

public interface IComponentHolder
{
    /// <summary>
    /// Attempts to retrieve a component of the specified type from game object
    /// </summary>
    /// <typeparam name="T">Type of component to retrieve</typeparam>
    /// <returns>True if the component was successfully found, false otherwise</returns>
    public bool TryGetComponent<T>(out T component);
}
