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
            Assert.IsNotNull(heart.BloodCirculation.BloodContents == null);
        }

        [Test]
        public void New_HasNerves()
        {
            Heart heart = new();
            Assert.IsNotNull(heart.Nerves);
        }
    }
}
