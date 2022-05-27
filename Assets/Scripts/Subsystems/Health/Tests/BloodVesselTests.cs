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
            var bloodVessel = new BloodVessel(10);
            Assert.NotNull(bloodVessel.Volume);
        }

        [Test]
        public void New_NoFluid()
        {
            var bloodVessel = new BloodVessel(10);
            Assert.AreEqual(0, bloodVessel.Volume.Fluids.Measure.Value);
        }

        [Test]
        public void New_SourcesEmpty()
        {
            var bloodVessel = new BloodVessel(10);
            Assert.Zero(bloodVessel.Sources.Count);
        }

        [Test]
        public void New_SinksEmpty()
        {
            var bloodVessel = new BloodVessel(10);
            Assert.Zero(bloodVessel.Sinks.Count);
        }

        [Test]
        public void ConnectSource_AddsToSources()
        {
            var bloodVessel = new BloodVessel(10);
            var source = new BloodVessel(10);

            Assert.IsFalse(bloodVessel.Sources.Contains(source));
            Assert.IsFalse(source.Sinks.Contains(bloodVessel));

            bloodVessel.ConnectSource(source);

            Assert.IsTrue(bloodVessel.Sources.Contains(source));
            Assert.IsTrue(source.Sinks.Contains(bloodVessel));
        }

        [Test]
        public void ConnectSink_AddsToSinks()
        {
            var bloodVessel = new BloodVessel(10);
            var sink = new BloodVessel(10);

            Assert.IsFalse(bloodVessel.Sinks.Contains(sink));
            Assert.IsFalse(sink.Sources.Contains(bloodVessel));

            bloodVessel.ConnectSink(sink);

            Assert.IsTrue(bloodVessel.Sinks.Contains(sink));
            Assert.IsTrue(sink.Sources.Contains(bloodVessel));
        }
    }
}
