using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System;

namespace Fluids.Tests
{
    public class FluidContainerTests
    {
        [Test]
        public void FluidContainer_Constructor_ZeroOrNegativeThrowsException()
        {
            Assert.Throws<ArgumentException>(()=> new FluidContainer(0));
            Assert.Throws<ArgumentException>(()=> new FluidContainer(-1));
        }

        [Test]
        public void FluidContainer_Constructor_CapacityEqualsPassedValue()
        {
            float amount = 10;
            var container = new FluidContainer(amount);
            Assert.AreEqual(amount, container.Capacity.Amount);
            amount = 25;
            container = new FluidContainer(amount);
            Assert.AreEqual(amount, container.Capacity.Amount);
            amount = 1000000;
            container = new FluidContainer(amount);
            Assert.AreEqual(amount, container.Capacity.Amount);
            amount = Mathf.PI;
            container = new FluidContainer(amount);
            Assert.AreEqual(amount, container.Capacity.Amount);
        }
    }
}
