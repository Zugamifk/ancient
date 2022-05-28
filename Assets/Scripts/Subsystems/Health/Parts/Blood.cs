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
        public Percentage OxygenLevel { get; }
        public Measure Measure { get; }
        public Measure OxygenMeasure => Measure * OxygenLevel;

        public Blood(float measure) : this(measure, 0) { }
        public Blood(Measure measure, Percentage oxygenLevel) 
        {
            OxygenLevel = oxygenLevel;
            Measure = measure;
        }

        public bool IsOxygenated => OxygenMeasure > 0;

        public IFluid CombineWith(IFluid other)
        {
            throw new NotImplementedException();
        }
    }
}
