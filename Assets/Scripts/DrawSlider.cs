using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public enum ValueAction
{
    Add,
    Deprive
}

public class DrawSlider : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    [SerializeField] private float _minTime;
    [SerializeField] private float _maxTime;

    private ValueAction _valueAction;
  
    private IEnumerator LerpValue(float startValue, float endValue, float duration, UnityAction<float> action)
    {
        float elapsed = 0;
        float nextVallue;

        while (elapsed < duration)
        {
            nextVallue = Mathf.Lerp(startValue, endValue, elapsed / duration);
            action?.Invoke(nextVallue);
            elapsed += Time.deltaTime;
            yield return null;
        }
    }

    public void ChangeIndicatorValue(float currentValue,float value, ValueAction valueAction)
    {
        float normalizeValue = 0;    

        if (valueAction == ValueAction.Add)
        {
            normalizeValue = currentValue + value;
        }
        else if (valueAction == ValueAction.Deprive)
        {
            normalizeValue = currentValue - value;
        }

        float duration = Mathf.Lerp(_minTime, _maxTime, normalizeValue);
        StartCoroutine(LerpValue(currentValue, normalizeValue, duration, SetSliderValue));
    }

    private void SetSliderValue(float value)
    {
        _slider.value = value;
    }

    public void SetCurentValue(float currentValue)
    {
        _slider.value = currentValue;
    }
}
