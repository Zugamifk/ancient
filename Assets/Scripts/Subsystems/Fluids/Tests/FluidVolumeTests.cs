using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System;
using Core;

namespace Fluids.Tests
{
    public class FluidVolumeTests
    {
        class TestFluid : IFluid
        {
            public Measure Measure { get; set; }
        }

        [Test]
        public void Constructor_ZeroOrNegativeThrowsException()
        {
            Assert.Throws<ArgumentException>(()=> new FluidVolume(0));
            Assert.Throws<ArgumentException>(()=> new FluidVolume(-1));
        }

        [Test]
        public void Constructor_CapacityEqualsPassedValue()
        {
            float amount = 10;
            var container = new FluidVolume(amount);
            Assert.AreEqual(amount, container.Capacity.Value);
            amount = 25;
            container = new FluidVolume(amount);
            Assert.AreEqual(amount, container.Capacity.Value);
            amount = 1000000;
            container = new FluidVolume(amount);
            Assert.AreEqual(amount, container.Capacity.Value);
            amount = Mathf.PI;
            container = new FluidVolume(amount);
            Assert.AreEqual(amount, container.Capacity.Value);
        }
    }
}
