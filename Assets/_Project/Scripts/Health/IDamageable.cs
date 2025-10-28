using UnityEngine;

public interface IDamageable
{
    /// <summary>
    /// Defines whether the object is still considered valid for taking damage or damage is irrelevant (aka is already dead/broken/etc)
    /// </summary>
    public bool IsAlive { get; }

    /// <summary>
    /// Deals damage to the damageable and returns if afterwards the damageable will still be alive
    /// </summary>
    /// <param name="damage"></param>
    /// <returns>True if object is alive after damage dealt, false otherwise</returns>
    public bool TakeDamage(int damage);
}
