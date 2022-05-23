using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Fluids.Tests
{
    public class FluidContainerTests
    {
        // A Test behaves as an ordinary method
        [Test]
        public void FluidContainer_EmptyConstructor_ZeroCapacityAndMeasure()
        {
            var container = new FluidContainer();
            Assert.AreEqual(container.Amount.Measure, 0);
            Assert.AreEqual(container.Capacity.Measure, 0);
        }
    }
}
