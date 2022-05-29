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
            IHasName heart = new Heart(1);
            Assert.IsNotEmpty(heart.Name);
        }

        [Test]
        public void New_HasBloodVessels()
        {
            Heart heart = new(1);
            Assert.IsNotNull(heart.BloodCirculation);
        }

        [Test]
        public void New_HasNoBlood()
        {
            Heart heart = new(1);
            Assert.That(heart.BloodCirculation.HasBlood, Is.False);
        }

        [Test]
        public void New_HeartRate_IsRegular()
        {
            Heart heart = new(1);
            Assert.That(heart.HeartRate, Is.InRange(60, 100));
        }

        [Test]
        public void New_BloodCirculationCapacity_MatchesGivenCapacity(
            [Values(1, Mathf.PI, 100, 9999)] float capacity)
        {
            Heart heart = new(capacity);
            Assert.That(heart.BloodCirculation.Volume.Capacity.Value, Is.EqualTo(capacity));
        }

        [Test]
        public void PulseContract_HeartHasBlood_AddsBloodToSink(
            [Values(1, Mathf.PI, 1000)] float amount)
        {
            var sink = new BloodCirculation(amount);
            var heart = new Heart(amount);
            heart.BloodCirculation.Volume.Add(new Blood(amount));
            heart.BloodCirculation.ConnectSink(sink);

            Assume.That(sink.HasBlood, Is.False);
            Assume.That(heart.BloodCirculation.HasBlood, Is.True);
            Assume.That(heart.BloodCirculation.HasSink(sink), Is.True);

            heart.PulseContract();

            Assert.That(sink.BloodContents.Measure.Value, Is.EqualTo(amount));
        }

        [Test]
        public void PulseContract_HeartEmpty_AddsNoBloodToSink(
            [Values(1, Mathf.PI, 1000)] float capacity)
        {
            var sink = new BloodCirculation(capacity);
            var heart = new Heart(capacity);
            heart.BloodCirculation.ConnectSink(sink);

            Assume.That(sink.HasBlood, Is.False);
            Assume.That(heart.BloodCirculation.HasBlood, Is.False);
            Assume.That(heart.BloodCirculation.HasSink(sink), Is.True);

            heart.PulseContract();

            Assert.That(sink.HasBlood, Is.False);
        }

        [Test]
        public void PulseContract_MultipleSinks_SplitsBetweenSinks(
            [Values(1, 2, 3, 10, Mathf.PI)] float sinkCapacityA,
            [Values(1, 2, 3, 10, Mathf.PI)] float sinkCapacityB)
        {
            var sinkA = new BloodCirculation(sinkCapacityA);
            var sinkB = new BloodCirculation(sinkCapacityB);
            var totalCapacity = sinkCapacityA + sinkCapacityB;
            var heart = new Heart(totalCapacity);
            heart.BloodCirculation.Volume.Add(new Blood(totalCapacity));
            heart.BloodCirculation.ConnectSink(sinkA);
            heart.BloodCirculation.ConnectSink(sinkB);

            heart.PulseContract();

            Assert.That(sinkA.BloodContents.Measure.Value, Is.EqualTo(sinkCapacityA));
            Assert.That(sinkB.BloodContents.Measure.Value, Is.EqualTo(sinkCapacityB));
        }

        [Test]
        public void PulseContract_MultipleSinks_NotFull_SplitsProportionally(
            [Values(1, 2, 3, 10, Mathf.PI)] float sinkCapacityA,
            [Values(1, 2, 3, 10, Mathf.PI)] float sinkCapacityB,
            [Values(.1f, .25f, .75f)] float proportion)
        {
            var sinkA = new BloodCirculation(sinkCapacityA);
            var sinkB = new BloodCirculation(sinkCapacityB);
            var totalCapacity = sinkCapacityA + sinkCapacityB;
            var heart = new Heart(totalCapacity);
            heart.BloodCirculation.Volume.Add(new Blood(totalCapacity * proportion));
            heart.BloodCirculation.ConnectSink(sinkA);
            heart.BloodCirculation.ConnectSink(sinkB);

            heart.PulseContract();

            Assert.That(Mathf.Approximately(sinkA.BloodContents.Measure.Value, sinkCapacityA * proportion), Is.True);
            Assert.That(Mathf.Approximately(sinkB.BloodContents.Measure.Value, sinkCapacityB * proportion), Is.True);
        }
    }
}
