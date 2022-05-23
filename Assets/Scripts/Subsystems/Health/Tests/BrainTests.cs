using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Health.Tests
{
    public class BrainTests
    {
        const string TEST_BRAIN_NAME = "BRAIN TEST";

        [Test]
        public void NewBrain_EmptyConstructor_HasName()
        {
            IHasName brain = new Brain();
            Assert.IsNotEmpty(brain.Name);
        }

        [Test]
        public void NewBrain_NamedConstructor_StartsWithOwnerName()
        {
            IHasName brain = new Brain(TEST_BRAIN_NAME);
            Assert.IsTrue(brain.Name.StartsWith(TEST_BRAIN_NAME));
        }
    }
}
