using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretProjectileModel : ITurretProjectileModel, IIdentifiable, IKeyHolder
{
    public string Key { get; set; }
    public Guid Id { get; } = new Guid();
    public float FlightProgress { get; set;}
    public Vector2 Position { get; set; }
}
