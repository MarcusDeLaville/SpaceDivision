using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using DG.Tweening;

public class Interaction : MonoBehaviour
{
    [SerializeField] private Image _travelImage;

    [SerializeField] private EnergyStorage _energyStorage;
    [SerializeField] private SupplySystem _supplySystem;
    [SerializeField] private Hint _hint;
    [SerializeField] private KeyCode _interactionButton = KeyCode.E;

    [SerializeField] private float _energyBankCapacity;
    [SerializeField] private float _foodBankCapcity;

    private Coroutine _waitOpenDoor;

    public UnityEvent WinEvent;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Energy")
        {
            Destroy(collision.gameObject);
            _energyStorage.AddEnergy(_energyBankCapacity);
        }
        // реализация через тэги не конечно не самая хорошая, но времени на отдельные скрипты не хватило(
        if (collision.gameObject.tag == "Food")
        {
            Destroy(collision.gameObject);
            _supplySystem.AddFood(_foodBankCapcity);
        }

        if(collision.gameObject.TryGetComponent(out SimpleDoor simpleDoor))
        {
            _hint.ShowNewHint("Нажмите Е чтобы войти.");

            _waitOpenDoor = StartCoroutine(CheakOpenDoor(simpleDoor));
        }

        if (collision.gameObject.TryGetComponent(out RedDoor redDoor))
        {
            _hint.ShowNewHint("Нажмите Е чтобы войти в красную дверь.");

            _waitOpenDoor = StartCoroutine(CheakOpenRedDoor(redDoor));
        }
    }

    private IEnumerator CheakOpenDoor(SimpleDoor simpleDoor)
    {
        yield return new WaitUntil(() => Input.GetKeyDown(_interactionButton));

        _travelImage.DOFillAmount(1, 1f).SetDelay(1f);
        _travelImage.DOFillAmount(0, 1f).SetDelay(3.5f);

        simpleDoor.OnInteraction(gameObject);
    }

    private IEnumerator CheakOpenRedDoor(RedDoor redDoor)
    {
        yield return new WaitUntil(() => Input.GetKeyDown(_interactionButton));

        if (_energyStorage.EnergyCount >= 70)
        {
            yield return new WaitForSeconds(1.0f);
            redDoor.OnInterection(_energyStorage, WinEvent);
        }
    }

}
