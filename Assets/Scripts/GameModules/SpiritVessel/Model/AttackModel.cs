using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpiritVessel.ViewModel;
using System;

namespace SpiritVessel.Model
{
    public class AttackModel : IAttackModel
    {
        public Guid Id { get; } = Guid.NewGuid();

        public string Key { get; set; }

        public Guid MapId { get; set; }
        public Vector2 Position { get; set; }
    }
}
