using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fluids;

namespace Health
{
    public class BloodVesselModel
    {
        public FluidContainer BloodVolume { get; }

        public BloodVesselModel(float capacity)
        {
            BloodVolume = new FluidContainer(capacity);
        }
    }
}
