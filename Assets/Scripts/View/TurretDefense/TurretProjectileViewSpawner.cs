using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretProjectileViewSpawner : ViewSpawner<ITurretProjectileModel, TurretProjectile>
{
    protected override IIdentifiableLookup<ITurretProjectileModel> GetIdentifiables() => Game.Model.TurretDefense.Projectiles;
}
