using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _health;
    [SerializeField] private float _addHealth;
    [SerializeField] private float _damage;
    [SerializeField] private float _changeSliderSpeed;

    private Coroutine _coroutine;
    private float _target;

    private void Start()
    {
        _health.value = _health.maxValue;
    }

    public void TakeHealth()
    {
        _target = _health.value + DividerDirection(_addHealth);
        TryGetCoroutine();
        _coroutine = StartCoroutine(ChangeHealth(_target, _addHealth));
    }

    public void TakeDamage()
    {
        _target = _health.value - DividerDirection(_damage);
        TryGetCoroutine();
        _coroutine = StartCoroutine(ChangeHealth(_target, _damage));
    }

    private IEnumerator ChangeHealth(float target, float direction)
    {
        while (_health.value != target)
        {
            _health.value = Mathf.MoveTowards(_health.value, target, direction * Time.deltaTime * _changeSliderSpeed);
            yield return null;
        }
    }

    private float DividerDirection(float direction)
    {
        float divider = 100;
        return direction /= divider;
    }

    private Coroutine TryGetCoroutine()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
        return _coroutine;
    }
}
