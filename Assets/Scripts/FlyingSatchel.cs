using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingSatchel : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private EnergyStorage _energyStorage;
    [SerializeField] private float _spendingMultiplier;

    public bool IsWork { get; private set; } = false;

    public void ActiveFly(float power)
    {
        if(_energyStorage.EnergyCount >= Mathf.Abs(power) * _spendingMultiplier)
        {
            IsWork = true;
            _energyStorage.DepriveEnergy(Mathf.Abs(power) * _spendingMultiplier);
        }
        else
        {
            IsWork = false;
        }
    }

    public void DisableFly()
    {
        IsWork = false;
    }
}
