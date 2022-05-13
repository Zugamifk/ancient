using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretProjectileModel : ITurretProjectileModel, IIdentifiable
{
    public Guid Id { get; } = new Guid();
    public float FlightProgress { get; set;}
    public Vector2 Position { get; set; }

}
