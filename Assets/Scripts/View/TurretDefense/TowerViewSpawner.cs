using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class TowerViewSpawner : MapViewSpawner<ITurretModel, Tower>
    {
        protected override IIdentifiableLookup<ITurretModel> GetIdentifiables() => Game.Model.TurretDefense.Turrets;
    }
}