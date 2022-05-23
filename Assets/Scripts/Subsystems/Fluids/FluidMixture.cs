using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;

namespace Fluids
{
    public class FluidMixture
    {
        Dictionary<Type, Measure> _fluidToMeasure = new Dictionary<Type, Measure>();
        public Measure Amount { get; }

        //public void AddFluid<TFluid>(TFluid fluid)
        //{

        //}

        //public FluidMeasure GetAmountOfFluid<TFluid>()
        //{
        //    if (_fluidToMeasure.TryGetValue(typeof(TFluid), out var measure))
        //    {
        //        return measure;
        //    }
        //    else
        //    {
        //        return default;
        //    }
        //}
    }
}
