using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretProjectileViewSpawner : ViewSpawner<ITurretProjectileModel, TurretProjectile>
{
    class PrefabLookup : IPrefabLookup
    {
        public GameObject Prefab;
        public GameObject GetPrefab(string key)
        {
            return Prefab;
        }
    }
    public TurretProjectileViewSpawner(GameObject projectilePrefab, Transform viewParent) : base(new PrefabLookup() { Prefab = projectilePrefab }, viewParent)
    {
    }

    protected override IIdentifiableLookup<ITurretProjectileModel> GetIdentifiables() => Game.Model.TurretDefense.Projectiles;

    protected override string GetPrefabKey(ITurretProjectileModel model) => string.Empty;
}
