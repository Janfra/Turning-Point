using UnityEngine;
using UnityEngine.Events;

public class HealthComponent : MonoBehaviour, IDamageable
{
    [SerializeField]
    private int _maxHealth = 1;
    public int MaxHealth => _maxHealth;

    public int CurrentHealth => _currentHealth;
    private int _currentHealth;

    public bool IsAlive => _isAlive;
    private bool _isAlive;

    [SerializeField, Tooltip("Event for when death is started, however is in the process of handling, e.g. death animation playing")]
    private UnityEvent _onDeathStart;
    [SerializeField, Tooltip("Event for when death is complete and the object is ready for clearing.")]
    private UnityEvent _onDeathEnd;

    private void OnEnable()
    {
        ResetHealth();
    }

    public bool TakeDamage(int damage)
    {
        _currentHealth -= damage;
        if (_currentHealth <= 0)
        {
            Die();
            return IsAlive;
        }
        return IsAlive;
    }

    public void ResetHealth()
    {
        _currentHealth = _maxHealth;
        _isAlive = true;
    }

    private void Die()
    {
        _isAlive = false;
        _onDeathStart?.Invoke();
    }

    private void OnHandleDeathEnd()
    {
        _onDeathEnd?.Invoke();
    }
}
