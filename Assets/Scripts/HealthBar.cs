using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private float _changeSliderSpeed;

    private Coroutine _coroutine;
    private Player _player;

    private void Start()
    {
        _player = GetComponent<Player>();
        _slider.maxValue = _player.Health;
        _slider.value = _slider.maxValue;
    }

    public void TakeSliderValue()
    {
        HaveCoroutine();
        _coroutine = StartCoroutine(ChangeHealth());
    }

    public void DecreaseSliderValue()
    {
        HaveCoroutine();
        _coroutine = StartCoroutine(ChangeHealth());
    }

    public IEnumerator ChangeHealth()
    {
        float distance = 5;

        while (_slider.value != _player.Health)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, _player.Health, distance * Time.deltaTime * _changeSliderSpeed);
            yield return null;
        }
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
