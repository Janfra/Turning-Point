using UnityEngine;

public class TargetableHealthComponent : HealthComponent, ITargetable
{
    public Transform Transform => transform;

    [Header("Debugging")]
    public LogComponent Logger;

    public void OnTargeted()
    {
        Logger?.Log("Targeted Health", this);
    }

    public void OnReached(ContactData data)
    {
        TakeDamage(data.Damage);
    }
}
