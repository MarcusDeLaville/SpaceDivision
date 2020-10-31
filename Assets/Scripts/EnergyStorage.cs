using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnergyStorage : MonoBehaviour
{
    [SerializeField] private float _energyCount;
    [SerializeField] private float _maximumEnergyCapacity;
    [SerializeField] private float _minimumEnergyRecoveries;
    [SerializeField] private float _energyRecoveriesPerSeconds;

    [SerializeField] private DrawSlider _drawSlider;

    public float EnergyCount => _energyCount;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("PowerCount"))
        {
            _energyCount = PlayerPrefs.GetFloat("PowerCount");
        }
        else
        {
            _energyCount = 35;
        }
    }

    private void Start()
    {
        _drawSlider.SetCurentValue(_energyCount);
        StartCoroutine(Recoveries());
    }

    public void AddEnergy(float value)
    {
        if (_energyCount > _maximumEnergyCapacity)
        {
            _energyCount = _maximumEnergyCapacity;
        }

        _drawSlider.ChangeIndicatorValue(_energyCount, value, ValueAction.Add);
        _energyCount += value;

        SaveProgress();      
    }

    public void DepriveEnergy(float value)
    {
        _drawSlider.ChangeIndicatorValue(_energyCount, value, ValueAction.Deprive);
        _energyCount -= value;

        SaveProgress();
    }

    private IEnumerator Recoveries()
    {
        while (true)
        {
            yield return new WaitUntil(() => _energyCount < _minimumEnergyRecoveries);
            _energyCount += _energyRecoveriesPerSeconds;
            _drawSlider.ChangeIndicatorValue(_energyCount, _energyRecoveriesPerSeconds, ValueAction.Add);
            yield return new WaitForSeconds(1);
        }
    }

    private void SaveProgress()
    {
        PlayerPrefs.SetFloat("PowerCount", _energyCount);
        PlayerPrefs.Save();
    }
}
