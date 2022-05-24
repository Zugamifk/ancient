using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Health.Tests
{
    public class NervousSystemTests
    {
        [Test]
        public void Constructor_HasBrain()
        {
            var nervousSystem = new NervousSystem(new());
            Assert.IsNotNull(nervousSystem.Brain);
        }
    }
}
