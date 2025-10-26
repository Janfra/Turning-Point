using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    [SerializeField]
    private int _maxHealth = 1;
    private int _currentHealth;

    private void OnEnable()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}
