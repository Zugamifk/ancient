using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense.ViewModel
{
    public interface ITower : IIdentifiable, IKeyHolder, IMapPositionable
    {
        float AttackRadius { get; }
        IEnumerable<Guid> EnemiesInRange { get; }
    }
}