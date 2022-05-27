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
        public void NewBody_EmptyConstructor_HasName()
        {
            IHasName body = new HumanBody();
            Assert.IsNotEmpty(body.Name);
        }

        [Test]
        public void NewBody_NamedConstructor_HasGivenName()
        {
            IHasName body = new HumanBody(TEST_BODY_NAME);
            Assert.AreEqual(body.Name, TEST_BODY_NAME);
        }

        [Test]
        public void NewBody_HasHead()
        {
            HumanBody body = new HumanBody(TEST_BODY_NAME);
            Assert.NotNull(body.Head);
        }
    }
}