using System;
using UnityEngine;

public interface ITargetable
{
    public Transform Transform { get; }
    public void OnTargeted();
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
