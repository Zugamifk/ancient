using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpiritVessel.ViewModel;
using System;

namespace SpiritVessel.Model
{
    public class AttackModel : IAttackModel
    {
        public Guid Id { get; } = new();

        public string Key { get; set; }

        public Vector2 Position { get; set; }
    }
}
