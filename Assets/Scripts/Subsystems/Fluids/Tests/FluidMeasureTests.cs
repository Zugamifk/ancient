using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System;

namespace Fluids.Tests
{
    public class FluidMeasureTests
    {
        [Test]
        public void NewMeasure_EmptyConstructor_MeasureZero()
        {
            var measure = new FluidMeasure();
            Assert.AreEqual(measure.Amount, 0);
        }

        [Test]
        public void NewMeasure_AmountEqualsGiven()
        {
            var measure = new FluidMeasure(100);
            Assert.AreEqual(measure.Amount, 100);
        }

        [Test]
        public void NewMeasure_NegativeAmount_Throws()
        {
            Assert.Throws<ArgumentException>(()=> new FluidMeasure(-100));
        }

        [Test]
        public void AddMeasure_AddsAmounts()
        {
            var a = new FluidMeasure(2);
            var b = new FluidMeasure(3);
            var sum = a + b;
            Assert.AreEqual(sum.Amount, 5);
        }
    }
}
