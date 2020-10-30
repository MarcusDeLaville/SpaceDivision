using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SupplySystem : MonoBehaviour
{
    [SerializeField] private float _foodCount;
    [SerializeField] private float _maximumFoodCount = 100;
    [SerializeField] private float _depriveFoodPerTick;

    [SerializeField] private DrawSlider _foodSlider;

    public UnityEvent Die;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("FoodCount"))
        {
            _foodCount = PlayerPrefs.GetFloat("FoodCount");
        }
        else
        {
            _foodCount = 70;
        }
    }

    private void Start()
    {
        StartCoroutine(Hunger());
    }

    public void AddFood(float value)
    {
        if (_foodCount > _maximumFoodCount)
        {
            _foodCount = _maximumFoodCount;
        }

        _foodSlider.ChangeIndicatorValue(_foodCount, value, ValueAction.Add);
        _foodCount += value;

        SaveProgress();
    }

    public void DepriveFood(float value)
    {
        _foodSlider.ChangeIndicatorValue(_foodCount, value, ValueAction.Deprive);
        _foodCount -= value;

        if (_foodCount <= 0)
        {
            Die.Invoke();
        }

        SaveProgress();
    }

    private IEnumerator Hunger()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);
            DepriveFood(_depriveFoodPerTick);
        }
    }

    private void SaveProgress()
    {
        PlayerPrefs.SetFloat("FoodCount", _foodCount);
        PlayerPrefs.Save();
    }

    //private void OnApplicationQuit()
    //{
    //    PlayerPrefs.SetFloat("FoodCount", _foodCount);
    //    PlayerPrefs.Save();
    //}

    //private void OnApplicationPause(bool pause)
    //{
    //    PlayerPrefs.SetFloat("FoodCount", _foodCount);
    //    PlayerPrefs.Save();
    //}
}
