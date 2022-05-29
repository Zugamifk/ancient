using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fluids;
using Core;
using System;

namespace Health
{
    public readonly struct Blood : IFluid
    {
        public Percent OxygenLevel { get; }
        public Measure Measure { get; }
        public Measure OxygenMeasure => Measure * OxygenLevel;

        public Blood(Measure measure) : this(measure, Percent.Zero) { }
        public Blood(Measure measure, Percent oxygenLevel) 
        {
            OxygenLevel = oxygenLevel;
            Measure = measure;
        }

        public bool IsOxygenated => OxygenMeasure > 0;

        public IFluid CombineWith(IFluid other)
        {
            return new Blood(other.Measure+Measure);
        }
    }
}
