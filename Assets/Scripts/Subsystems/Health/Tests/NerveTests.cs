using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Health.Tests
{
    public class NerveTests
    {
        const string TEST_NERVE_NAME = "NERVE TEST";

        [Test]
        public void EmptyConstructor_HasName()
        {
            IHasName nerve = new Nerve();
            Assert.IsNotEmpty(nerve.Name);
        }

        [Test]
        public void NamedConstructor_StartsWithOwnerName()
        {
            IHasName nerve = new Nerve(TEST_NERVE_NAME);
            Assert.IsTrue(nerve.Name.StartsWith(TEST_NERVE_NAME));
        }

        [Test]
        public void NewNerve_HasConnectedSet()
        {
            Nerve nerve = new Nerve(TEST_NERVE_NAME);
            Assert.NotNull(nerve.Connected);
        }

        [Test]
        public void NewNerve_HasNoConnections()
        {
            Nerve nerve = new Nerve(TEST_NERVE_NAME);
            Assert.Zero(nerve.Connected.Count);
        }
    }
}
