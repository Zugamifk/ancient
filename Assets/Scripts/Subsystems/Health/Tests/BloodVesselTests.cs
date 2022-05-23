using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Health.Tests
{
    public class BloodVesselTests
    {
        [Test]
        public void Constructor_HasVolume()
        {
            var bloodVessel = new BloodVessel(10);
            Assert.NotNull(bloodVessel.Volume);
        }
    }
}
