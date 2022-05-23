using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;

namespace Fluids
{
    public class FluidMixture : IFluid
    {
        Dictionary<Type, IFluid> _fluidToMeasure = new Dictionary<Type, IFluid>();
        public Measure Measure { get; private set; }

        public void AddFluid<TFluid>(TFluid fluid)
            where TFluid : IFluid               
        {
            Measure += fluid.Measure.Value;
        }

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
