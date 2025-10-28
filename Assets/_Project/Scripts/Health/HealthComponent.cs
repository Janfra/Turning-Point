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

    [SerializeField]
    private UnityEvent _onDeath;

    private void OnEnable()
    {
        _currentHealth = _maxHealth;
        _isAlive = true;
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

    private void Die()
    {
        _isAlive = false;
        _onDeath?.Invoke();
    }
}
