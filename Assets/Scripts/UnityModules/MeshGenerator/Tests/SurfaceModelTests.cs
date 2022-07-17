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

            builder.AddPoint(Vector3.zero);

            Assert.That(model.Vertices.Count, Is.EqualTo(1));
        }

        [Test]
        public void ConnectPoints_CreatesEdge()
        {
            var model = new SurfaceModel();
            var builder = new SurfaceModelBuilder(model);

            builder.AddPoint(Vector3.zero);
            builder.AddPoint(Vector3.up);
            builder.ConnectPoints(0, 1);

            Assert.That(model.Edges.Count, Is.EqualTo(1));
        }

        [Test]
        public void ConnectPoints_CreatesHalfEdges()
        {
            var model = new SurfaceModel();
            var builder = new SurfaceModelBuilder(model);

            builder.AddPoint(Vector3.zero);
            builder.AddPoint(Vector3.up);
            builder.ConnectPoints(0, 1);

            var edge = model.Edges[0];
            var h1 = edge.HalfEdge;
            var h2 = h1.Twin;

            Assert.That(model.HalfEdges.Count, Is.EqualTo(2));
            Assert.That(h1, Is.Not.Null);
            Assert.That(h2, Is.Not.Null);
            Assert.That(model.HalfEdges.Contains(h1));
            Assert.That(model.HalfEdges.Contains(h2));
        }

        [Test]
        public void ConnectPoints_CreatedHalfEdgesAssignedToEdge()
        {
            var model = new SurfaceModel();
            var builder = new SurfaceModelBuilder(model);

            builder.AddPoint(Vector3.zero);
            builder.AddPoint(Vector3.up);
            builder.ConnectPoints(0, 1);

            var edge = model.Edges[0];
            var h1 = edge.HalfEdge;
            var h2 = h1.Twin;

            Assert.That(h1.Edge, Is.EqualTo(edge));
            Assert.That(h2.Edge, Is.EqualTo(edge));
        }

        [Test]
        public void ConnectPoints_CreatedHalfEdgesAreTwins()
        {
            var model = new SurfaceModel();
            var builder = new SurfaceModelBuilder(model);

            builder.AddPoint(Vector3.zero);
            builder.AddPoint(Vector3.up);
            builder.ConnectPoints(0, 1);

            var edge = model.Edges[0];
            var h1 = edge.HalfEdge;
            var h2 = h1.Twin;

            Assert.That(h1.Twin, Is.EqualTo(h2));
            Assert.That(h2.Twin, Is.EqualTo(h1));
        }

        [Test]
        public void ConnectPoints_AssignsHalfEdgeToOrphanVertex()
        {
            var model = new SurfaceModel();
            var builder = new SurfaceModelBuilder(model);

            builder.AddPoint(Vector3.zero);
            builder.AddPoint(Vector3.up);
            builder.ConnectPoints(0, 1);

            var v1 = model.Vertices[0];
            var v2 = model.Vertices[1];

            Assert.That(v1.HalfEdge, Is.Not.Null);
            Assert.That(v2.HalfEdge, Is.Not.Null);
        }

        [Test]
        public void ConnectPoints_ThrowOutOfRangeException_IfNoPoints()
        {
            var model = new SurfaceModel();
            var builder = new SurfaceModelBuilder(model);

            Assert.That(()=> builder.ConnectPoints(0, 1), 
                Throws.InstanceOf<System.ArgumentOutOfRangeException>());
        }

        [Test]
        public void ConnectPoints_AssignsVertexToHalfEdges()
        {
            var model = new SurfaceModel();
            var builder = new SurfaceModelBuilder(model);

            builder.AddPoint(Vector3.zero);
            builder.AddPoint(Vector3.up);
            builder.ConnectPoints(0, 1);

            var h1 = model.HalfEdges[0];
            var h2 = model.HalfEdges[1];

            Assert.That(h1.Vertex, Is.Not.Null);
            Assert.That(h2.Vertex, Is.Not.Null);
        }
    }
}
