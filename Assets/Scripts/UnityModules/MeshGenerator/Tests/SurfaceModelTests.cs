using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace MeshGenerator.Tests
{
    public class SurfaceModelTests
    {
        [Test]
        public void New_IsEmpty()
        {
            var model = new SurfaceModel();

            Assert.That(model.Edges, Is.Empty);
            Assert.That(model.Faces, Is.Empty);
            Assert.That(model.HalfEdges, Is.Empty);
            Assert.That(model.Vertices, Is.Empty);
        }

        [Test]
        public void IsEmpty_TrueIfEmpty()
        {
            var model = new SurfaceModel();

            Assert.That(model.IsEmpty);
        }

        [Test]
        public void IsEmpty_FalseIfNotEmpty()
        {
            var model = new SurfaceModel();
            model.Vertices.Add(new Vertex());

            Assert.That(model.IsEmpty, Is.False);
        }

        [Test]
        public void NewBuild_EmptyModel()
        {
            var model = new SurfaceModel();
            var builder = new SurfaceModelBuilder(model);
            Assert.That(model.IsEmpty);
        }

        [Test]
        public void AddPoint_AddsVertex()
        {
            var model = new SurfaceModel();
            var builder = new SurfaceModelBuilder(model);

            model = builder.AddPoint(Vector3.zero).Build();

            Assert.That(model.Vertices.Count == 1);
        }
    }
}
