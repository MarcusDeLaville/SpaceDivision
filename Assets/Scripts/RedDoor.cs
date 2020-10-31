using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RedDoor : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private float _requiredEnergy = 70;

    private EnergyStorage _playerEnergyStorage;
    private UnityEvent _finalAction;

    public void OnInterection(EnergyStorage energyStorage, UnityEvent doorEvent)
    {
        _playerEnergyStorage = energyStorage;
        _finalAction = doorEvent;

        if(_playerEnergyStorage.EnergyCount >= _requiredEnergy)
        {
            _playerEnergyStorage.DepriveEnergy(_requiredEnergy * 10000);
            StartCoroutine(OpenRedDoor());
        }
    }

    private IEnumerator OpenRedDoor()
    {
        yield return new WaitForSeconds(1f);
        _animator.SetBool("isOpen", true);
        yield return new WaitForSeconds(1f);
        _finalAction.Invoke();
    }
}
