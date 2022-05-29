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
#region New
        [Test]
        public void New_EmptyConstructor_MeasureZero()
        {
            var measure = new Measure();
            Assert.AreEqual(measure.Value, 0);
        }

        [Test]
        public void New_AmountEqualsGiven()
        {
            var measure = new Measure(100);
            Assert.AreEqual(measure.Value, 100);
        }

        [Test]
        public void New_NegativeAmount_Throws()
        {
            Assert.Throws<ArgumentException>(()=> new Measure(-100));
        }
#endregion

#region IsEmpty
        [Test]
        public void IsEmpty_ZeroMeasure_True()
        {
            var measure = new Measure(0);
            Assert.That(measure.IsEmpty, Is.True);
        }

        [Test]
        public void IsEmpty_OneMeasure_False()
        {
            var measure = new Measure(1);
            Assert.That(measure.IsEmpty, Is.False);
        }

#endregion

#region Cast
        [Test]
        public void ImplicitCast_FromFloat_ValueMatches()
        {
            Measure measure = 1;
            Assert.That(measure.Value, Is.EqualTo(1));
        }

        [Test]
        public void ImplicitCast_FromNegativeFloat_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Measure invalid = -1;
            });
        }

        #endregion

#region Combine
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
        #endregion

#region Scale
        [Test]
        public void MultiplyPercent_ReturnsPercentOfAmount()
        {
            var a = new Measure(10);
            var b = new Percent(50);
            var half = a * b;
            Assert.AreEqual(half.Value, 5);
            half = b * a;
            Assert.AreEqual(half.Value, 5);
        }

        [Test]
        public void MultiplyNumber_ReturnsMeasureWithValueMultiplied()
        {
            var big = 1000f;

            var m0 = new Measure(0);
            var m1 = new Measure(1);
            var mPi = new Measure(Mathf.PI);
            var mBig = new Measure(big);

            var n0 = 0f;
            var n1 = 1f;
            var nPi = Mathf.PI;
            var nBig = big;

            Assert.That(m0 * n0, Is.EqualTo(new Measure(0)));
            Assert.That(m0 * n1, Is.EqualTo(new Measure(0)));
            Assert.That(m0 * nPi, Is.EqualTo(new Measure(0)));
            Assert.That(m0 * nBig, Is.EqualTo(new Measure(0)));

            Assert.That(m1 * n0, Is.EqualTo(new Measure(0)));
            Assert.That(m1 * n1, Is.EqualTo(new Measure(1)));
            Assert.That(m1 * nPi, Is.EqualTo(new Measure(Mathf.PI)));
            Assert.That(m1 * nBig, Is.EqualTo(new Measure(big)));

            Assert.That(mPi * n0, Is.EqualTo(new Measure(0)));
            Assert.That(mPi * n1, Is.EqualTo(new Measure(Mathf.PI)));
            Assert.That(mPi * nPi, Is.EqualTo(new Measure(Mathf.PI * Mathf.PI)));
            Assert.That(mPi * nBig, Is.EqualTo(new Measure(Mathf.PI * big)));

            Assert.That(mBig * n0, Is.EqualTo(new Measure(0)));
            Assert.That(mBig * n1, Is.EqualTo(new Measure(big)));
            Assert.That(mBig * nPi, Is.EqualTo(new Measure(big * Mathf.PI)));
            Assert.That(mBig * nBig, Is.EqualTo(new Measure(big * big)));
        }
        #endregion

        #region Compare
#pragma warning disable CS1718
        [Test]
        public void LessThan_ComparesValues()
        {
            Measure zero = 0;
            Measure one = 1;
            Assert.IsTrue(zero < one);
            Assert.IsFalse(one < zero); 
            Assert.IsFalse(zero < zero);
            Assert.IsFalse(one < one);
        }

        [Test]
        public void LessThanOrEqual_ComparesValues()
        {
            Measure zero = 0;
            Measure one = 1;
            Assert.IsTrue(zero <= one);
            Assert.IsTrue(zero <= zero);
            Assert.IsTrue(one <= one);
            Assert.IsFalse(one <= zero);
        }

        [Test]
        public void GreaterThan_ComparesValues()
        {
            Measure zero = 0;
            Measure one = 1;
            Assert.IsFalse(zero > one);
            Assert.IsTrue(one > zero);
            Assert.IsFalse(zero > zero);
            Assert.IsFalse(one > one);
        }

        [Test]
        public void GreaterThanOrEqual_ComparesValues()
        {
            Measure zero = 0;
            Measure one = 1;
            Assert.IsFalse(zero >= one);
            Assert.IsTrue(zero >= zero);
            Assert.IsTrue(one >= one);
            Assert.IsTrue(one >= zero);
        }

        [Test]
        public void IsEqual_ComparesValues()
        {
            Measure zero = 0;
            Measure one = 1;
            Assert.IsFalse(zero == one);
            Assert.IsTrue(zero == zero);
            Assert.IsTrue(one == one);
            Assert.IsFalse(one == zero);
        }

        [Test]
        public void IsNotEqual_ComparesValues()
        {
            Measure zero = 0;
            Measure one = 1;
            Assert.IsTrue(zero != one);
            Assert.IsFalse(zero != zero);
            Assert.IsFalse(one != one);
            Assert.IsTrue(one != zero);
        }
#pragma warning restore CS1718
        #endregion
    }
}
