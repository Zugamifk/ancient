using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Health.Tests
{
    public class HeadTests
    {
        const string TEST_HEAD_NAME = "HEADTEST";

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
            Assert.IsNotNull(head.BloodVessels);
        }

        [Test]
        public void NewHead_HasNoBlood()
        {
            Head head = new Head();
            Assert.IsNotNull(head.BloodVessels.BloodContents == null);
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
    }
}
