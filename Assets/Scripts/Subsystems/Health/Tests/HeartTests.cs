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
            Assert.IsNotNull(heart.BloodVessels);
        }

        [Test]
        public void New_HasNoBlood()
        {
            Heart heart = new();
            Assert.IsNotNull(heart.BloodVessels.BloodContents == null);
        }
    }
}
