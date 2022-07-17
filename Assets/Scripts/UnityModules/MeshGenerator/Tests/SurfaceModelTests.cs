using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace MeshGenerator.Tests
{
    public class SurfaceModelTests
    {
        // A Test behaves as an ordinary method
        [Test]
        public void New_IsEmpty()
        {
            var model = new SurfaceModel();

            Assert.That(model.Edges, Is.Empty);
            Assert.That(model.Faces, Is.Empty);
            Assert.That(model.HalfEdges, Is.Empty);
            Assert.That(model.Vertices, Is.Empty);
        }
    }
}
