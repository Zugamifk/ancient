using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Core;

namespace Fluids
{
    public class FluidVolume
    {
        public Measure Capacity { get; }
        public FluidMixture Fluids { get; } = new FluidMixture();

        public FluidVolume(Measure capacity)
        {
            if (capacity.Value <= 0)
            {
                throw new ArgumentException("Fluid capacity can not be zero!");
            }
            Capacity = capacity;
        }

        public void Add(IFluid fluid)
        {
            throw new NotImplementedException();
        }
    }
}
