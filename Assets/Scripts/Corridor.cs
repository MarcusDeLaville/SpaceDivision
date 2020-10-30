using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corridor : MonoBehaviour
{
    [SerializeField] private Transform _playerSpawnPoint;

    public Transform PlayerSpawnPoint => _playerSpawnPoint;
}
