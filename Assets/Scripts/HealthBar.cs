using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private float _changeSliderSpeed;

    public IEnumerator ChangeHealth(Slider health, float target, float direction)
    {
        while (health.value != target)
        {
            health.value = Mathf.MoveTowards(health.value, target, direction * Time.deltaTime * _changeSliderSpeed);
            yield return null;
        }
    }
}
