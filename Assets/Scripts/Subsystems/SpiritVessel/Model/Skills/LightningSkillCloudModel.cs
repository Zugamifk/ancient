using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpiritVessel.Model
{
    public class LightningSkillCloudModel
    {
        public Guid Id { get; } = Guid.NewGuid();
        public Vector2 Position { get; set; }
        public float Radius { get; set; }
    }
}
