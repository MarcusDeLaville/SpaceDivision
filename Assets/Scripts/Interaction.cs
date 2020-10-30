using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interaction : MonoBehaviour
{
    [SerializeField] private EnergyStorage _energyStorage;
    [SerializeField] private SupplySystem _supplySystem;
    [SerializeField] private Hint _hint;
    [SerializeField] private KeyCode _interactionButton = KeyCode.E;

    [SerializeField] private float _energyBankCapacity;
    [SerializeField] private float _foodBankCapcity;

    private Coroutine _waitOpenDoor;
    private bool _isInteract;

    public UnityEvent OpenRedDoor;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Energy")
        {
            Destroy(collision.gameObject);
            _energyStorage.AddEnergy(_energyBankCapacity);
        }
        else if (collision.gameObject.tag == "Food")
        {
            Destroy(collision.gameObject);
            _supplySystem.AddFood(_foodBankCapcity);
        }

        //простите, я тут спешил  

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
        simpleDoor.OnInteraction(gameObject);
    }

    private IEnumerator CheakOpenRedDoor(RedDoor redDoor)
    {
        yield return new WaitUntil(() => Input.GetKeyDown(_interactionButton));
        if (_energyStorage.EnergyCount >= 70)
        {
            yield return new WaitForSeconds(1.0f);
            OpenRedDoor.Invoke();
        }
    }

}
