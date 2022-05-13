using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretDefenseViews : MonoBehaviour
{
    [SerializeField]
    Transform _projectilesRoot;
    [SerializeField]
    GameObject _projectilePrefab;

    ViewSpawner<ITurretProjectileModel, TurretProjectile> _projectiles;

    private void Awake()
    {
        _projectiles = new TurretProjectileViewSpawner(_projectilePrefab, _projectilesRoot);
    }
}
