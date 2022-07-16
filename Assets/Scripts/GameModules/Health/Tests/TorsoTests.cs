using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Health.Tests
{
    public class TorsoTests
    {
        [Test]
        public void NewTorso_HasName()
        {
            IHasName torso = new Torso();
            Assert.IsNotEmpty(torso.Name);
        }

        [Test]
        public void New_HasHeart()
        {
            Torso torso = new();
            Assert.IsNotNull(torso.Heart);
        }

        [Test]
        public void New_HasBloodVessels()
        {
            Torso torso = new();
            Assert.IsNotNull(torso.BloodCirculation);
        }

        [Test]
        public void New_HasNoBlood()
        {
            Torso torso = new();
            Assert.That(torso.BloodCirculation.HasBlood, Is.False);
        }

        [Test]
        public void New_HasNerves()
        {
            Torso torso = new();
            Assert.IsNotNull(torso.Nerves);
        }

        //[Test]
        //public void New_HeartBloodHasTorsoSink()
        //{
        //    Torso torso = new();
        //    var heartVessels = torso.Heart._bloodCirculation;
        //    var torsoVessels = torso.BloodCirculation;
        //    Assert.IsTrue(heartVessels.HasSink(torsoVessels));
        //}

        //[Test]
        //public void New_HeartBloodHasTorsoSource()
        //{
        //    Torso torso = new();
        //    var heartVessels = torso.Heart._bloodCirculation;
        //    var torsoVessels = torso.BloodCirculation;
        //    Assert.IsTrue(heartVessels.HasSource(torsoVessels));
        //}
    }
}
