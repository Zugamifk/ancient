using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITurretModel : IIdentifiable, IKeyHolder
{
    Vector2Int Position { get; }
    float AttackRadius { get; }
    IEnumerable<Guid> EnemiesInRange { get; }
}
