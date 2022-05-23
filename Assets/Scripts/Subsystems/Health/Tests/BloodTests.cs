using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

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
            Assert.AreEqual(blood.Measure, 0);
        }
    }
}
