using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Health.Tests
{
    public class HeadTests
    {
        [Test]
        public void NewHead_HasName()
        {
            IHasName head = new Head();
            Assert.IsNotEmpty(head.Name);
        }
        
        [Test]
        public void NewHead_HasSkull()
        {
            Head head = new Head();
            Assert.IsNotNull(head.Skull);
        }

        [Test]
        public void NewHead_HasBloodVessels()
        {
            Head head = new Head();
            Assert.IsNotNull(head.BloodCirculation);
        }

        [Test]
        public void NewHead_HasNoBlood()
        {
            Head head = new Head();
            Assert.That(head.BloodCirculation.HasBlood, Is.False);
        }

        [Test]
        public void NewHead_HasBrain()
        {
            Head head = new Head();
            Assert.IsNotNull(head.Brain);
        }

        [Test]
        public void NewHead_HasNerves()
        {
            Head head = new Head();
            Assert.IsNotNull(head.Nerves);
        }

        [Test]
        public void NewHead_NervesConnectedToBrain()
        {
            Head head = new Head();
            Assert.IsTrue(head.Nerves.IsConnectedTo(head.Brain.Nerves));
        }

        [Test]
        public void New_HeadBloodHasBrainSink()
        {
            Head head = new Head();
            var headVessels = head.BloodCirculation;
            var brainVessels = head.Brain.BloodCirculation;
            Assert.IsTrue(headVessels.HasSink(brainVessels));
        }

        [Test]
        public void New_HeadBloodHasBrainSource()
        {
            Head head = new Head();
            var headVessels = head.BloodCirculation;
            var brainVessels = head.Brain.BloodCirculation;
            Assert.IsTrue(headVessels.HasSource(brainVessels));
        }
    }
}
