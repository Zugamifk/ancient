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
        [Test]
        public void Constructor_ZeroMeasure()
        {
            var mixture = new FluidMixture();
            Assert.AreEqual(0, mixture.Measure.Value);
        }

        [Test]
        public void EmptyFluid_DoesNotContainFluid()
        {
            var mixture = new FluidMixture();
            Assert.IsFalse(mixture.ContainsFluid<TestFluid>());
        }

        [Test]
        public void AddFluid_IncreasesAmount()
        {
            var mixture = new FluidMixture();
            var fluid = new TestFluid(10);
            mixture.AddFluid(fluid);
            Assert.AreEqual(10, mixture.Measure.Value);
        }

        [Test]
        public void AddFluid_AddsFluid()
        {
            var mixture = new FluidMixture();
            var fluid = new TestFluid(10);
            mixture.AddFluid(fluid);
            Assert.IsTrue(mixture.ContainsFluid<TestFluid>());
        }
    }
}
