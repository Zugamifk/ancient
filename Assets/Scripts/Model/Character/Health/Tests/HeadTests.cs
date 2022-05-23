using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Health.Tests
{
    public class HeadTests
    {
        const string TEST_HEAD_NAME = "Name";

        [Test]
        public void NewHead_EmptyConstructor_HasName()
        {
            IHasName head = new HeadModel();
            Assert.IsNotEmpty(head.Name);
        }

        [Test]
        public void NewHead_NamedConstructor_StartsWithOwnerName()
        {
            IHasName head = new HeadModel(TEST_HEAD_NAME);
            Assert.IsTrue(head.Name.StartsWith(TEST_HEAD_NAME));
        }
    }
}
