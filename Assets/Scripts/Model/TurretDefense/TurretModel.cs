using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretModel : ITurretModel
{
    public string Name { get; set; }
    public Guid Id { get; set; } = Guid.NewGuid();
    public Vector2Int Position { get; set; }
    public float AttackRadius { get; set; }
    public HashSet<Guid> EnemiesInRange = new HashSet<Guid>();

    IEnumerable<Guid> ITurretModel.EnemiesInRange => EnemiesInRange;
}
