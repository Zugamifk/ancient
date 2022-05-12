using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretModel : ITurretModel
{
    public float AttackRadius { get; set; }
    public Guid Id { get; set; }
    public HashSet<Guid> EnemiesInRange = new HashSet<Guid>();

    IEnumerable<Guid> ITurretModel.EnemiesInRange => EnemiesInRange;
}
