using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Desk : MonoBehaviour
{
    [SerializeField]
    DeskItemPrefabs _prefabs;
    [SerializeField]
    DeskItemSpawn[] _spawns;

    Dictionary<string, DeskItemSpawn> _spawnNameToSpawn = new Dictionary<string, DeskItemSpawn>();

    void Awake()
    {
        foreach (var s in _spawns)
        {
            _spawnNameToSpawn[s.SpawnName] = s;
        }
        var itemSpawner = new DeskItemViewSpawner(_prefabs, transform, _spawnNameToSpawn);
    }
}
