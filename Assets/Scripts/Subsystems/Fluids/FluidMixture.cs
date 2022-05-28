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
        public Measure Measure { get => _measure; set => throw new InvalidOperationException("Can't explicitly change measure of a fluid misxture! Call AddFluid() instead!"); }

        public void AddFluid<TFluid>(TFluid fluid)
            where TFluid : IFluid
        {
            var contained = GetFluid<TFluid>();
            if (contained != null)
            {
                throw new NotImplementedException();
            }
            else
            {
                _fluidToMeasure.Add(typeof(TFluid), fluid);
            }
            _measure += fluid.Measure.Value;
        }

        public IFluid CombineWith(IFluid other)
        {
            throw new NotImplementedException();
        }

        public bool ContainsFluid<TFluid>() => _fluidToMeasure.ContainsKey(typeof(TFluid));

        public TFluid GetFluid<TFluid>()
            where TFluid : IFluid
        {
            if (_fluidToMeasure.TryGetValue(typeof(TFluid), out IFluid fluid))
            {
                return (TFluid)fluid;
            }
            else
            {
                return default;
            }
        }
    }
}
