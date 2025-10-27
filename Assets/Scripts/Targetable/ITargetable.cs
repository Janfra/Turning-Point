using System;
using UnityEngine;

public interface ITargetable : IComponentHolder
{
    /// <summary>
    /// Reference to the targetable positional data
    /// </summary>
    public Transform Transform { get; }

    /// <summary>
    /// Informs targetable that it is being targeted
    /// </summary>
    public void OnTargeted();

    /// <summary>
    /// Informs the targetable that is has been reached and provides the contact data of the object
    /// </summary>
    /// <param name="data"></param>
    public void OnReached(ContactData data);
}

[Serializable]
public struct ContactData
{
    public int Damage;
    public float Force;
    [HideInInspector]
    public Vector2 Direction;

    ContactData(int damage, float force, Vector2 direction)
    {
        Damage = damage;
        Force = force;
        Direction = direction;
    }
}
