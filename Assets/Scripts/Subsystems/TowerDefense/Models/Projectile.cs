using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TowerDefense.ViewModels;

namespace TowerDefense.Models
{
    public class Projectile : IProjectile, IIdentifiable, IKeyHolder
    {
        public string Key { get; set; }
        public Guid Id { get; } = Guid.NewGuid();
        public float FlightProgress { get; set; }
        public Vector2 Position { get; set; }
    }
}