using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParralaxBackground : MonoBehaviour
{
    [SerializeField] private Transform _playerPosition;

    private void Update()
    {
        transform.position = _playerPosition.position;
    }

}
