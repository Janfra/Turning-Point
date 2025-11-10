using System;
using UnityEngine;
using UnityEngine.Pool;

/// <summary>
/// Defines an object as poolable, allowing it to be returned to its pool when no longer needed.
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IPoolable<T> where T : class
{
    /// <summary>
    /// Gets the pool that this object belongs to. WARNING: This property is automatically set when the object is created by the pool, do not set it manually.
    /// </summary>
    public IObjectPool<T> Pool { get; set; }

    public void ReleaseToPool()
    {
        Pool?.Release(this as T);
    }
}
