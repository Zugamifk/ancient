using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Fluids;

namespace Health.Tests
{
    public class BloodTests
    {
        [Test]
        public void New_EmptyConstructor_NoOxygen()
        {
            var blood = new Blood();
            Assert.AreEqual((float)blood.OxygenLevel, 0);
        }

        [Test]
        public void New_EmptyConstructor_MeasureZero()
        {
            IFluid blood = new Blood();
            Assert.AreEqual(blood.Measure.Value, 0);
        }

        [Test]
        public void New_WithMeasure_AssignsMeasure()
        {
            var blood = new Blood(100);
            Assert.AreEqual(100, blood.Measure.Value);

            blood = new Blood(0);
            Assert.AreEqual(0, blood.Measure.Value);

            blood = new Blood(Mathf.PI);
            Assert.AreEqual(Mathf.PI, blood.Measure.Value);
        }

        [Test]
        public void New_WithNegativeMeasure_ThrowArgumentException()
        {
            Assert.That(() => new Blood(-1), Throws.ArgumentException);
        }

        [Test]
        public void New_WithOxygenLevel_AssignsOxygenLevel()
        {
            var blood = new Blood(100, 100);
            Assert.AreEqual(100, blood.OxygenLevel.Value);

            blood = new Blood(100, 0);
            Assert.AreEqual(0, blood.OxygenLevel.Value);

            blood = new Blood(100, Mathf.PI);
            Assert.AreEqual(Mathf.PI, blood.OxygenLevel.Value);
        }

        [Test]
        public void OxygenMeasure_IsPercentageOfOxygenLevel()
        {
            var blood = new Blood(100,100);
            Assert.AreEqual(blood.OxygenMeasure.Value, 100);
            blood = new(100, 50);
            Assert.AreEqual(blood.OxygenMeasure.Value, 50);
            blood = new(50, 50);
            Assert.AreEqual(blood.OxygenMeasure.Value, 25);
            blood = new(100, 0);
            Assert.AreEqual(blood.OxygenMeasure.Value, 0);
            blood = new(0, 100);
            Assert.AreEqual(blood.OxygenMeasure.Value, 0);
        }

        [Test]
        public void IsOxygenated_OxygenMeasureZero_ReturnsFalse()
        {
            Blood blood = new(100, 0);
            Assert.That(blood.IsOxygenated, Is.False);
        }

        [Test]
        public void IsOxygenated_OxygenMeasureNotZero_ReturnsTrue()
        {
            Blood blood = new(100, 100);
            Assert.That(blood.IsOxygenated, Is.True);

            blood = new(100, 1);
            Assert.That(blood.IsOxygenated, Is.True);
        }

        [Test]
        public void CombineWith_MoreBlood_ReturnsNewBlood()
        {
            Blood bloodA = new(100);
            Blood bloodB = new(100);
            IFluid combined = bloodA.CombineWith(bloodB);
            Assert.That(combined is Blood, Is.True);
        } 
    }
}
