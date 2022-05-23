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
            var blood = new BloodModel();
            Assert.AreEqual((float)blood.OxygenLevel, 0);
        }

        [Test]
        public void NewBlood_EmptyConstructor_MeasureZero()
        {
            IFluid blood = new BloodModel();
            Assert.AreEqual(blood.Measure.Measure, 0);
        }

        [Test]
        public void OxygenMeasure_IsPercentageOfOxygenLevel()
        {
            var blood = new BloodModel();
            blood.Measure = 100;
            blood.OxygenLevel = 100;
            Assert.AreEqual(blood.OxygenMeasure.Measure, 100);
            blood.OxygenLevel = 50;
            Assert.AreEqual(blood.OxygenMeasure.Measure, 50);
            blood.Measure = 50;
            Assert.AreEqual(blood.OxygenMeasure.Measure, 25);
            blood.OxygenLevel = 0;
            Assert.AreEqual(blood.OxygenMeasure.Measure, 0);
            blood.OxygenLevel = 100;
            blood.Measure = 0;
            Assert.AreEqual(blood.OxygenMeasure.Measure, 0);
        }
    }
}
