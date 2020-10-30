using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public enum TypeDoor
{
    InSpace,
    InRoom
}

public class SimpleDoor : MonoBehaviour
{
    [SerializeField] private TypeDoor _typeDoor;
    [SerializeField] private MapGenerator _mapGenerator;
    [SerializeField] private Animator _animator;
    [SerializeField] private SpriteRenderer _starsWay;

    [SerializeField] private bool _isHole;

    private void Start()
    {
        _typeDoor = Random.Range(0, 2) == 0 ? TypeDoor.InSpace : TypeDoor.InRoom;
        _mapGenerator = FindObjectOfType<MapGenerator>();
    }

    public void OnInteraction(GameObject player)
    {
        StartCoroutine(OpenDoor(player));
    }

    private IEnumerator OpenDoor(GameObject player)
    {
        if (!_isHole)
        {
            _animator.SetBool("isOpen", true);
        }
        else
        {
            _typeDoor = TypeDoor.InRoom;
        }
        

        yield return new WaitForSeconds(1.5f);

        if (_typeDoor == TypeDoor.InSpace)
        {
            _mapGenerator.RegenerationMap();
            player.transform.position = Vector2.zero;
        }
        else if (_typeDoor == TypeDoor.InRoom)
        {
            _mapGenerator.SpawnRoom(player);
        }
    }
}
