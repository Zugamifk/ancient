using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TowerDefense.ViewModels;

namespace TowerDefense.Views
{
    public class ProjectileViewSpawner : ViewSpawner<IProjectile, Projectile>
    {
        protected override IIdentifiableLookup<IProjectile> GetIdentifiables() => Game.Model.TowerDefense.Projectiles;
    }
}