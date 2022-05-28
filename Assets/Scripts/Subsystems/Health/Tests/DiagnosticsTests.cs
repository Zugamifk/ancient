using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Health.Tests
{
    public class DiagnosticsTests
    {
        [Test]
        public void NewBody_IsAlive()
        {
            var body = new HumanBody();
            var diagnostics = new Diagnostics(body);
            Assert.IsTrue(diagnostics.IsAlive());
        }
    }
}
