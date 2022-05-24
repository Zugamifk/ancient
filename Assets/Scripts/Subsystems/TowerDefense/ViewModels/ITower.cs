using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense.ViewModels
{
    public interface ITower : IIdentifiable, IKeyHolder
    {
        Vector2Int Position { get; }
        float AttackRadius { get; }
        IEnumerable<Guid> EnemiesInRange { get; }
    }
}