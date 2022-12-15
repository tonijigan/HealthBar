using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(HealthBar))]
public class Player : MonoBehaviour
{
    [SerializeField] private Slider _health;
    [SerializeField] private float _addHealth;
    [SerializeField] private float _damage;

    private HealthBar _healthBar;
    private Coroutine _coroutine;
    private float _target;

    public void TakeHealth()
    {
        _target = _health.value + DividerDirection(_addHealth);
        HaveCoroutine();
        _coroutine = StartCoroutine(_healthBar.ChangeHealth(_health, _target, _addHealth));
    }

    public void TakeDamage()
    {
        _target = _health.value - DividerDirection(_damage);
        HaveCoroutine();
        _coroutine = StartCoroutine(_healthBar.ChangeHealth(_health, _target, _damage));
    }

    private void Start()
    {
        _healthBar = GetComponent<HealthBar>();
        _health.value = _health.maxValue;
    }

    private float DividerDirection(float direction)
    {
        float divider = 100;
        return direction /= divider;
    }

    private Coroutine HaveCoroutine()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
        return _coroutine;
    }
}
