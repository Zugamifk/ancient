using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITurretModel : IIdentifiable
{
    Vector2Int Position { get; }
    string Name { get; }
    float AttackRadius { get; }
    IEnumerable<Guid> EnemiesInRange { get; }
}
