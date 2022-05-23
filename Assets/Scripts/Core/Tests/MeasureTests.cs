using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System;
using Core;

namespace Core.Tests
{
    public class MeasureTests
    {
        [Test]
        public void NewMeasure_EmptyConstructor_MeasureZero()
        {
            var measure = new Measure();
            Assert.AreEqual(measure.Value, 0);
        }

        [Test]
        public void NewMeasure_AmountEqualsGiven()
        {
            var measure = new Measure(100);
            Assert.AreEqual(measure.Value, 100);
        }

        [Test]
        public void NewMeasure_NegativeAmount_Throws()
        {
            Assert.Throws<ArgumentException>(()=> new Measure(-100));
        }

        [Test]
        public void AddMeasure_AddsAmounts()
        {
            var a = new Measure(2);
            var b = new Measure(3);
            var sum = a + b;
            Assert.AreEqual(sum.Value, 5);
        }

        [Test]
        public void AddFloat_AddsAmounts()
        {
            var a = new Measure(2);
            var b = 3;
            var sum = a + b;
            Assert.AreEqual(sum.Value, 5);
            sum = b + a;
            Assert.AreEqual(sum.Value, 5);
        }

        [Test]
        public void SubtractMeasure_SubtractsAmounts()
        {
            var a = new Measure(5);
            var b = new Measure(2);
            var sum = a - b;
            Assert.AreEqual(sum.Value, 3);
        }

        [Test]
        public void SubtractFloat_SubtractsAmounts()
        {
            var a = new Measure(5);
            var b = 2;
            var sum = a - b;
            Assert.AreEqual(sum.Value, 3);
            a = new Measure(2);
            b = 5;
            sum = b - a;
            Assert.AreEqual(sum.Value, 3);
        }

        [Test]
        public void SubtractMeasure_ThrowsOnNegativeResult()
        {
            Assert.Throws<ArgumentException>(()=>
            {
                var a = new Measure(2);
                var b = new Measure(5);
                var sum = a - b;
            });
        }

        [Test]
        public void MultiplyPercent_ReturnsPercentOfAmount()
        {
            var a = new Measure(10);
            var b = new Percentage(50);
            var half = a * b;
            Assert.AreEqual(half.Value, 5);
            half = b * a;
            Assert.AreEqual(half.Value, 5);
        }
    }
}
