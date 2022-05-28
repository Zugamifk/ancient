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
        [Test]
        public void New_ZeroOrNegativeThrowsException()
        {
            Assert.Throws<ArgumentException>(()=> new FluidVolume(0));
            Assert.Throws<ArgumentException>(()=> new FluidVolume(-1));
        }

        [Test]
        public void New_CapacityEqualsPassedValue()
        {
            float amount = 10;
            var volume = new FluidVolume(amount);
            Assert.AreEqual(amount, volume.Capacity.Value);
            amount = 25;
            volume = new FluidVolume(amount);
            Assert.AreEqual(amount, volume.Capacity.Value);
            amount = 1000000;
            volume = new FluidVolume(amount);
            Assert.AreEqual(amount, volume.Capacity.Value);
            amount = Mathf.PI;
            volume = new FluidVolume(amount);
            Assert.AreEqual(amount, volume.Capacity.Value);
        }

        [Test]
        public void New_ZeroMeasure()
        {
            var container = new FluidVolume(10);
            Assert.AreEqual(0, container.Fluids.Measure.Value);
        }

        [Test]
        public void Add_MeasureEqualsAddedAmount()
        {
            var volume = new FluidVolume(1);
            var f = new TestFluid(.5f);
        }
    }
}
