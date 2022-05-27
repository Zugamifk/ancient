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
            Assert.IsNotNull(torso.BloodVessels);
        }

        [Test]
        public void New_HasNoBlood()
        {
            Torso torso = new();
            Assert.IsNotNull(torso.BloodVessels.BloodContents == null);
        }

        [Test]
        public void New_HasNerves()
        {
            Torso torso = new();
            Assert.IsNotNull(torso.Nerves);
        }
    }
}
