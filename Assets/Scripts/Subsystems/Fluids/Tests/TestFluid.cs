using Core;
using Fluids;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fluids.Tests
{
    internal class TestFluid : IFluid
    {
        public Measure Measure { get; set; }
        public TestFluid(Measure m) => Measure = m;

        public IFluid CombineWith(IFluid other) => new TestFluid(Measure + other.Measure);
    }
}
