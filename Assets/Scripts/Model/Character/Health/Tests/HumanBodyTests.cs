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
            var body = new HumanBodyModel();
            Assert.IsNotEmpty(body.Name);
        }

        [Test]
        public void NewBody_NamedConstructor_HasGivenName()
        {
            var body = new HumanBodyModel(TEST_BODY_NAME);
            Assert.AreEqual(body.Name, TEST_BODY_NAME);
        }
    }
}