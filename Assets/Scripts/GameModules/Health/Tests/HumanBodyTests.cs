using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Health;

namespace Health.Tests
{
    public class HumanBodyTests
    {
        const string TEST_BODY_NAME = "Body Name";

        [Test]
        public void New_EmptyConstructor_HasName()
        {
            IHasName body = new HumanBody();
            Assert.IsNotEmpty(body.Name);
        }

        [Test]
        public void New_NamedConstructor_HasGivenName()
        {
            IHasName body = new HumanBody(TEST_BODY_NAME);
            Assert.AreEqual(body.Name, TEST_BODY_NAME);
        }

        [Test]
        public void New_HasHead()
        {
            HumanBody body = new HumanBody(TEST_BODY_NAME);
            Assert.NotNull(body.Head);
        }

        [Test]
        public void New_HasTorso()
        {
            HumanBody body = new HumanBody(TEST_BODY_NAME);
            Assert.NotNull(body.Torso);
        }

        [Test]
        public void New_TorsoBloodHasHeadSink()
        {
            HumanBody body = new HumanBody(TEST_BODY_NAME);
            Assert.IsTrue(body.Torso.BloodCirculation.HasSink(body.Head.BloodCirculation));
        }

        [Test]
        public void New_TorsoBloodHasHeadSource()
        {
            HumanBody body = new HumanBody(TEST_BODY_NAME);
            Assert.IsTrue(body.Torso.BloodCirculation.HasSource(body.Head.BloodCirculation));
        }
    }
}