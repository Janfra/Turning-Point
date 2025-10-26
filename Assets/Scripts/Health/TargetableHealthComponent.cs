using UnityEngine;

public class TargetableHealthComponent : HealthComponent, ITargetable
{
    public Transform Transform => transform;

    public void OnTargeted()
    {
        Debug.Log("Targeted Health");
    }

    public void OnReached(ContactData data)
    {
        TakeDamage(data.Damage);
    }
}
