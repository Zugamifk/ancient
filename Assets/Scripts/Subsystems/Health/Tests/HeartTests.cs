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
        public void PulseExpand_SourceHasBlood_FillsHeart()
        {
            var source = new BloodCirculation(10);
            source.Volume.Add(new Blood(10));
            var heart = new Heart();
            heart.PulseExpand();
            Assert.That(heart.BloodCirculation.HasBlood, Is.True);
        }

        [Test]
        public void PulseContract_HeartHasBlood_FillsSink()
        {
            var sink = new BloodCirculation(10);
            sink.Volume.Add(new Blood(10));
            var heart = new Heart();
            heart.BloodCirculation.ConnectSink(sink);
            heart.PulseContract();
            Assert.That(heart.BloodCirculation.HasBlood, Is.True);
        }
    }
}
