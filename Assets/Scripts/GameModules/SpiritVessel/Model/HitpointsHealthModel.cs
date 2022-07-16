using SpiritVessel.ViewModel;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpiritVessel.Model
{
    public class HitpointsHealthModel  : IHitpointsHealthModel
    {
        public Guid Id { get; set; }
        public int Max { get; set; }
        public int Current { get; set; }
    }
}
