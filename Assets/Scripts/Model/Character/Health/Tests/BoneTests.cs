using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Health.Tests
{
    public class BoneTests
    {
        const string TEST_BONE_PART_NAME = "BODY PART";

        [Test]
        public void NewBone_EmptyConstructor_HasName()
        {
            IHasName bone = new BoneModel();
            Assert.IsNotEmpty(bone.Name);
        }

        [Test]
        public void NewBone_NamedConstructor_StartsWithPartName()
        {
            IHasName head = new BoneModel(TEST_BONE_PART_NAME);
            Assert.IsTrue(head.Name.StartsWith(TEST_BONE_PART_NAME));
        }
    }
}
