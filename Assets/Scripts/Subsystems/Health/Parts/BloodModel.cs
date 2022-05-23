using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fluids;

namespace Health
{
    public class BloodModel : IFluid
    {
        public Percentage OxygenLevel;
        public FluidMeasure Measure { get; set; }
        public FluidMeasure OxygenMeasure => Measure * OxygenLevel;
    }
}
