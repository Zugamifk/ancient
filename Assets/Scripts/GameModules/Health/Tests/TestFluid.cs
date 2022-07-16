using Core;
using Fluids;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Health.Tests
{
    internal class TestFluid : IFluid
    {
        public Measure Measure { get; set; }
        TestFluid(Measure m) => Measure = m;

        public IFluid CombineWith(IFluid other) => new TestFluid(Measure + other.Measure);
    }
}
