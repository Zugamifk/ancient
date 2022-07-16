using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TowerDefense.ViewModel;
using Map.View;
using System;

namespace TowerDefense.Views
{
    public class ProjectileViewSpawner : MapViewSpawner<IProjectile, Projectile>
    {
        protected override IEnumerable<IProjectile> AllModels() => Game.Model.GetModel<ITowerDefense>().Projectiles.AllItems;
        protected override IProjectile GetModel(Guid model) => Game.Model.GetModel<ITowerDefense>().Projectiles.GetItem(model);
    }
}