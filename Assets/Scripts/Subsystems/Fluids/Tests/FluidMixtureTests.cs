using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Fluids.Tests
{
    public class FluidMixtureTests
    {
        [Test]
        public void FluidMixture_Constructor_ZeroMeasure()
        {
            var mixture = new FluidMixture();
            Assert.AreEqual(0, mixture.Amount.Amount);
        }
    }
}
