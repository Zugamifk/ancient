using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretDefenseViews : MonoBehaviour
{
    [SerializeField]
    Transform _spawnsRoot;
    [SerializeField]
    GameObject _projectilePrefab;
    [SerializeField]
    TurretDefenseData _turretDefenseData;

    TurretPrefabLookup _turretPrefabs;
    TurretViewSpawner _turrets;
    TurretProjectileViewSpawner _projectiles;

    private void Awake()
    {
        _projectiles = new TurretProjectileViewSpawner(_projectilePrefab, _spawnsRoot);
        _turretPrefabs = new TurretPrefabLookup(_turretDefenseData);
        _turrets = new TurretViewSpawner(_turretPrefabs, _spawnsRoot);
    }
}
