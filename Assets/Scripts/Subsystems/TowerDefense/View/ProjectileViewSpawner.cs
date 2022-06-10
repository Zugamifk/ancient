using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TowerDefense.ViewModels;
using Map.View;

namespace TowerDefense.Views
{
    public class ProjectileViewSpawner : MapViewSpawner<IProjectile, Projectile>
    {
        protected override IIdentifiableLookup<IProjectile> GetIdentifiables() => Game.Model.TowerDefense.Projectiles;
    }
}