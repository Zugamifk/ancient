using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Health.Tests
{
    public class NerveTests
    {
        const string TEST_NERVE_NAME = "NERVE TEST";
        const string TEST_NERVE_NAME_OTHER = "OTHER NERVE TEST";

        [Test]
        public void NamedConstructor_StartsWithOwnerName()
        {
            IHasName nerve = new Nerve(TEST_NERVE_NAME);
            Assert.IsTrue(nerve.Name.StartsWith(TEST_NERVE_NAME));
        }

        [Test]
        public void New_HasConnectedSet()
        {
            Nerve nerve = new Nerve(TEST_NERVE_NAME);
            Assert.NotNull(nerve.Connected);
        }

        [Test]
        public void New_HasNoConnections()
        {
            Nerve nerve = new Nerve(TEST_NERVE_NAME);
            Assert.Zero(nerve.Connected.Count());
        }

        [Test]
        public void IsConnected_IsNotConnectedToOther_ReturnsFalse()
        {
            Nerve nerve = new Nerve(TEST_NERVE_NAME);
            Nerve other = new Nerve(TEST_NERVE_NAME_OTHER);
            Assert.IsFalse(nerve.IsConnectedTo(other));
        }

        [Test]
        public void IsConnected_IsConnectedToOther_ReturnsTrue()
        {
            Nerve nerve = new Nerve(TEST_NERVE_NAME);
            Nerve other = new Nerve(TEST_NERVE_NAME_OTHER);
            nerve.ConnectTo(other);
            Assert.IsTrue(nerve.IsConnectedTo(other));
        }
    }
}
