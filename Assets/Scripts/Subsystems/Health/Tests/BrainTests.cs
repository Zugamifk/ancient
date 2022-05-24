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
        public void New_HasName()
        {
            IHasName brain = new Brain();
            Assert.IsNotEmpty(brain.Name);
        }

        [Test]
        public void NewBrain_HasNerves()
        {
            Brain brain = new Brain();
            Assert.NotNull(brain.Nerves);
        }
    }
}
