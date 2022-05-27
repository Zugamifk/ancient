using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Health.Tests
{
    public class TorsoTests
    {
        [Test]
        public void NewTorso_HasName()
        {
            IHasName head = new Head();
            Assert.IsNotEmpty(head.Name);
        }
    }
}
