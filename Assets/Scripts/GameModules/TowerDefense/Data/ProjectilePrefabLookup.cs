using System.Collections;
using System.Collections.Generic;
using TowerDefense.ViewModel;
using UnityEngine;

namespace TowerDefense.Data
{
    public class ProjectilePrefabLookup : KeyHoldertoPrefabReferenceLookup<IProjectile, ProjectileData>
    {
        public ProjectileData[] Projectiles;
        protected override IEnumerable<ProjectileData> PrefabReferences => Projectiles;
    }
}
