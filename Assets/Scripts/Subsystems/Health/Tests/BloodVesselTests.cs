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
        public void New_HasVolume()
        {
            var bloodVessel = new BloodCirculation(10);
            Assert.NotNull(bloodVessel.Volume);
        }

        [Test]
        public void New_NoFluid()
        {
            var bloodVessel = new BloodCirculation(10);
            Assert.AreEqual(0, bloodVessel.Volume.Fluids.Measure.Value);
        }

        [Test]
        public void New_SourcesEmpty()
        {
            var bloodVessel = new BloodCirculation(10);
            Assert.Zero(bloodVessel.Sources.Count);
        }

        [Test]
        public void New_SinksEmpty()
        {
            var bloodVessel = new BloodCirculation(10);
            Assert.Zero(bloodVessel.Sinks.Count);
        }

        [Test]
        public void ConnectSource_AddsToSources()
        {
            var bloodVessel = new BloodCirculation(10);
            var source = new BloodCirculation(10);

            Assert.IsFalse(bloodVessel.HasSource(source));

            bloodVessel.ConnectSource(source);

            Assert.IsTrue(bloodVessel.HasSource(source));
        }

        [Test]
        public void ConnectSink_AddsToSinks()
        {
            var bloodVessel = new BloodCirculation(10);
            var sink = new BloodCirculation(10);

            Assert.IsFalse(bloodVessel.HasSink(sink));

            bloodVessel.ConnectSink(sink);

            Assert.IsTrue(bloodVessel.HasSink(sink));
        }
    }
}
