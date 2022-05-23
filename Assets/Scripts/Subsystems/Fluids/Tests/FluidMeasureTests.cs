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
            Assert.AreEqual(measure.Measure, 0);
        }

        [Test]
        public void NewMeasure_AmountEqualsGiven()
        {
            var measure = new FluidMeasure(100);
            Assert.AreEqual(measure.Measure, 100);
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
            Assert.AreEqual(sum.Measure, 5);
        }

        [Test]
        public void AddFloat_AddsAmounts()
        {
            var a = new FluidMeasure(2);
            var b = 3;
            var sum = a + b;
            Assert.AreEqual(sum.Measure, 5);
            sum = b + a;
            Assert.AreEqual(sum.Measure, 5);
        }

        [Test]
        public void SubtractMeasure_SubtractsAmounts()
        {
            var a = new FluidMeasure(5);
            var b = new FluidMeasure(2);
            var sum = a - b;
            Assert.AreEqual(sum.Measure, 3);
        }

        [Test]
        public void SubtractFloat_SubtractsAmounts()
        {
            var a = new FluidMeasure(5);
            var b = 2;
            var sum = a - b;
            Assert.AreEqual(sum.Measure, 3);
            a = new FluidMeasure(2);
            b = 5;
            sum = b - a;
            Assert.AreEqual(sum.Measure, 3);
        }

        [Test]
        public void SubtractMeasure_ThrowsOnNegativeResult()
        {
            Assert.Throws<ArgumentException>(()=>
            {
                var a = new FluidMeasure(2);
                var b = new FluidMeasure(5);
                var sum = a - b;
            });
        }

        [Test]
        public void MultiplyPercent_ReturnsPercentOfAmount()
        {
            var a = new FluidMeasure(10);
            var b = new Percentage(50);
            var half = a * b;
            Assert.AreEqual(half.Measure, 5);
            half = b * a;
            Assert.AreEqual(half.Measure, 5);
        }
    }
}
