using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PortalDefense.ViewModel;
using System;

namespace PortalDefense.Model
{
    public class EnemyModel : IEnemyModel
    {
        public Guid Id { get; } = Guid.NewGuid();

        public string Key { get; set; } = "Enemy";
        public MovementModel Movement { get; } = new();

        public Vector3 Position => Movement.CurrentPosition;
    }
}
