using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private UnityEvent _takeHealth, _takeDamage;

    private float _maxHealth;

    public float Health => _health;

    private void Start()
    {
        _maxHealth = _health;
    }

    public void TakeHealth(float addHealth)
    {
        if (_health < _maxHealth)
        {
            _health += addHealth;
            _takeHealth.Invoke();
        }
    }

    public void TakeDamage(float damage)
    {
        float _minHealth = 0;

        if (_health > _minHealth)
        {
            _health -= damage;
            _takeDamage.Invoke();
        }
    }
}
