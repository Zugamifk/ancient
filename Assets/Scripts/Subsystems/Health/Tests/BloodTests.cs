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
        public void NewBlood_EmptyConstructor_NoOxygen()
        {
            var blood = new Blood();
            Assert.AreEqual((float)blood.OxygenLevel, 0);
        }

        [Test]
        public void NewBlood_EmptyConstructor_MeasureZero()
        {
            IFluid blood = new Blood();
            Assert.AreEqual(blood.Measure.Value, 0);
        }

        [Test]
        public void OxygenMeasure_IsPercentageOfOxygenLevel()
        {
            var blood = new Blood();
            blood.Measure = 100;
            blood.OxygenLevel = 100;
            Assert.AreEqual(blood.OxygenMeasure.Value, 100);
            blood.OxygenLevel = 50;
            Assert.AreEqual(blood.OxygenMeasure.Value, 50);
            blood.Measure = 50;
            Assert.AreEqual(blood.OxygenMeasure.Value, 25);
            blood.OxygenLevel = 0;
            Assert.AreEqual(blood.OxygenMeasure.Value, 0);
            blood.OxygenLevel = 100;
            blood.Measure = 0;
            Assert.AreEqual(blood.OxygenMeasure.Value, 0);
        }
    }
}
