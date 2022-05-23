using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fluids;
using Core;

namespace Health
{
    public class Blood : IFluid
    {
        public Percentage OxygenLevel;
        public Measure Measure { get; set; }
        public Measure OxygenMeasure => Measure * OxygenLevel;
    }
}
