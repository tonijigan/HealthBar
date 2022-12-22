using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private float _addHealth;
    [SerializeField] private float _damage;
    [SerializeField] private UnityEvent _takeHealth, _takeDamage;

    private float _maxHealth;

    public float Health => _health;

    private void Start()
    {
        _maxHealth = _health;
    }

    public void TakeHealth()
    {
        if (_health < _maxHealth)
        {
            _health += _addHealth;
            _takeHealth.Invoke();
        }
    }

    public void TakeDamage()
    {
        float _minHealth = 0;

        if (_health > _minHealth)
        {
            _health -= _damage;
            _takeDamage.Invoke();
        }
    }
}
