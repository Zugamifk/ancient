using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpiritVessel.ViewModel;

namespace SpiritVessel.Model
{
    public class LightningSkillCloudModel : ILightningSkillCloudModel
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Key { get; } = "Cloud";
        public Vector2 Position { get; set; }
        public float Radius { get; set; }
        public float BoltTimer { get; set; }
    }
}
