using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fluids;

namespace Health
{
    public class BloodVesselModel
    {
        public FluidVolume Volume { get; }

        public BloodVesselModel(float capacity)
        {
            Volume = new FluidVolume(capacity);
        }
    }
}
