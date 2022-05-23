using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fluids;

namespace Health
{
    public class BloodVessel
    {
        public FluidVolume Volume { get; }
        public Blood BloodContents => Volume.Fluids.GetFluid<Blood>();
        public BloodVessel(float capacity)
        {
            Volume = new FluidVolume(capacity);
        }
    }
}
