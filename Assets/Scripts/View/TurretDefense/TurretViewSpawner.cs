using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretViewSpawner : MapViewSpawner<ITurretModel, Turret>
{
    protected override IIdentifiableLookup<ITurretModel> GetIdentifiables() => Game.Model.TurretDefense.Turrets;
}
