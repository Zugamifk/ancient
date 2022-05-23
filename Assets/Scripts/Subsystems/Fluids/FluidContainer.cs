using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Core;

namespace Fluids
{
    public class FluidContainer
    {
        public Measure Capacity { get; }

        public FluidContainer(Measure capacity)
        {
            if (capacity.Value <= 0)
            {
                throw new ArgumentException("Fluid capacity can not be zero!");
            }
            Capacity = capacity;
        }
    }
}
