using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Health.Tests
{
    public class BloodCirculationTests
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

        [Test]
        public void HasBlood_BloodContentsNull_ReturnsFalse()
        {
            var bloodVessel = new BloodCirculation(10);
            Assert.That(bloodVessel.HasBlood, Is.False);
        }

        [Test]
        public void HasBlood_BloodContentsNotNull_ReturnsTrue()
        {
            var bloodVessel = new BloodCirculation(10);
            bloodVessel.Volume.Add(new Blood(10));
            Assert.That(bloodVessel.HasBlood, Is.True);
        }

        [Test]
        public void IsAnoxic_LowOxygen_ReturnTrue()
        {
            var bloodVessel = new BloodCirculation(10);
            bloodVessel.Volume.Add(new Blood(10, 0));
            Assert.That(bloodVessel.IsAnoxic(), Is.True);
        }

        [Test]
        public void IsAnoxic_HighOxygen_ReturnFalse()
        {
            var bloodVessel = new BloodCirculation(10);
            bloodVessel.Volume.Add(new Blood(10, 100));
            Assert.That(bloodVessel.IsAnoxic(), Is.False);
        }
    }
}
