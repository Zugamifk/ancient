using System.Collections;
using System.Collections.Generic;
using TowerDefense.ViewModels;
using UnityEngine;

namespace TowerDefense.Data
{
    public class ProjectilePrefabLookup : SimplePrefabLookup<IProjectile, ProjectileData>
    {
        public ProjectileData[] Projectiles;
        protected override IEnumerable<ProjectileData> PrefabReferences => Projectiles;
    }
}
