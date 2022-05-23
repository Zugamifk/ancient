using System.Collections;
using System.Collections.Generic;
using Core;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Fluids.Tests
{
    public class FluidMixtureTests
    {
        class TestFluid : IFluid
        {
            public Measure Measure { get; set; }
        }

        [Test]
        public void Constructor_ZeroMeasure()
        {
            var mixture = new FluidMixture();
            Assert.AreEqual(0, mixture.Measure.Value);
        }

        [Test]
        public void AddFluid_IncreasesAmount()
        {
            var mixture = new FluidMixture();
            var fluid = new TestFluid()
            {
                Measure = 10
            };
            mixture.AddFluid(fluid);
            Assert.AreEqual(10, mixture.Measure.Value);
        }
    }
}
