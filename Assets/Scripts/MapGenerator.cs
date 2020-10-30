using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] private List<GameObject> _mapPrefabs;
    [SerializeField] private List<GameObject> _generatedObject;
    [SerializeField] private List<Corridor> _corridors;
    [SerializeField] private Transform _parrent;

    [SerializeField] private int _offsetX;
    [SerializeField] private int _offsetY;

    [SerializeField] private int _mapSize;

    private Corridor _spawnedCorridor;

    private void Start()
    {
        GenerateMap();
    }

    public void RegenerationMap()
    {
        for (int i = 0; i < _generatedObject.Count; i++)
        {
            Destroy(_generatedObject[i]);
        }

        GenerateMap();
    }

    private void GenerateMap()
    {
        Vector2 firstSpawnPosition = (-new Vector2(_offsetX, _offsetY) * (_mapSize / 2));
        Vector3 spawnPosition = firstSpawnPosition;


        for (int i = 0; i < _mapSize; i++)
        {
            for (int j = 0; j < _mapSize; j++)
            {
                SpawnPrefab(spawnPosition);
                spawnPosition += new Vector3(_offsetX, 0, 0);
            }

            spawnPosition += new Vector3(-_offsetX * _mapSize, _offsetY, 0);
        }
    }

    private void SpawnPrefab(Vector3 position)
    {
        _generatedObject.Add(Instantiate(_mapPrefabs[Random.Range(0, _mapPrefabs.Count)], position + new Vector3(Random.Range(-2, 2), 0, 0), Quaternion.identity, _parrent));
    }

    public void SpawnRoom(GameObject player)
    {
        if (_spawnedCorridor != null)
        {
            Destroy(_spawnedCorridor.gameObject);
        }
        _spawnedCorridor = Instantiate(_corridors[Random.Range(0, _corridors.Count)], new Vector3(500, 500, 0), Quaternion.identity);
        player.transform.position = _spawnedCorridor.PlayerSpawnPoint.position;
    }
}
