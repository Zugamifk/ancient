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
        Measure _measure;
        public Measure Measure { get => _measure; }

        public void AddFluid<TFluid>(TFluid fluid)
            where TFluid : IFluid
        {
            AddFluid(fluid, typeof(TFluid));
        }

        public IFluid CombineWith(IFluid other)
        {
            throw new NotImplementedException();
        }

        public bool ContainsFluid<TFluid>() => _fluidToMeasure.ContainsKey(typeof(TFluid));

        public TFluid GetFluid<TFluid>()
            where TFluid : IFluid
        {
            return default;
        }

        void AddFluid(IFluid fluid, Type type)
        {
            if(_fluidToMeasure.TryGetValue(type, out IFluid contained))
            {
                fluid = fluid.CombineWith(contained);
                _fluidToMeasure[type] = fluid;
            } else
            {
                _fluidToMeasure.Add(type, fluid);
            }
            _measure += fluid.Measure;
        }
    }
}
