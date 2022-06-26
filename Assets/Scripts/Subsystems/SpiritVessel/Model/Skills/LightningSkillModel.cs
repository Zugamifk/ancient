using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpiritVessel.Model
{
    public class LightningSkillModel
    {
        public float CoolDown { get; set; }
        public float Damage { get; set; }
        public float Radius { get; set; }
        public int Chains { get; set; }
        public bool HeavyRain { get; set; }
        public LightningSkillCloudModel[] Clouds { get; set; }
        public bool Ultimate { get; set; }
    }
}
