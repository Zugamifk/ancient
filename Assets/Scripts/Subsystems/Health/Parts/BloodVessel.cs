using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fluids;

namespace Health
{
    public class BloodVessel
    {
        public FluidVolume Volume { get; }
        public Blood BloodContents => throw new System.Exception();
        public BloodVessel(float capacity)
        {
            Volume = new FluidVolume(capacity);
        }
    }
}
