using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Health.Tests
{
    public class HeartTests
    {
        [Test]
        public void New_HasName()
        {
            IHasName heart = new Heart();
            Assert.IsNotEmpty(heart.Name);
        }

        [Test]
        public void New_HasBloodVessels()
        {
            Heart heart = new();
            Assert.IsNotNull(heart.BloodCirculation);
        }

        [Test]
        public void New_HasNoBlood()
        {
            Heart heart = new();
            Assert.That(heart.BloodCirculation.HasBlood, Is.False);
        }

        [Test]
        public void New_HeartRate_IsRegular()
        {
            Heart heart = new();
            Assert.That(heart.HeartRate, Is.InRange(60, 100));
        }

        [Test]
        public void PulseContract_HeartHasBlood_AddsBloodToSink()
        {
            var sink = new BloodCirculation(10);
            var heart = new Heart();
            heart.BloodCirculation.Volume.Add(new Blood(1));
            heart.BloodCirculation.ConnectSink(sink);

            Assume.That(sink.HasBlood, Is.False);
            Assume.That(heart.BloodCirculation.HasBlood, Is.True);
            Assume.That(heart.BloodCirculation.HasSink(sink), Is.True);

            heart.PulseContract();

            Assert.That(sink.HasBlood, Is.True);
        }
    }
}
