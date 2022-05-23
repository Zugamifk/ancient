using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Fluids
{
    public class FluidContainer
    {
        Dictionary<Type, FluidMeasure> _fluidToMeasure = new Dictionary<Type, FluidMeasure>();
        public FluidMeasure Amount { get; }
        public FluidMeasure Capacity { get; }
        public FluidMeasure GetAmountOfFluid<TFluid>()
        {
            if(_fluidToMeasure.TryGetValue(typeof(TFluid), out var measure))
            {
                return measure;
            } else
            {
                return default;
            }
        }
    }
}
