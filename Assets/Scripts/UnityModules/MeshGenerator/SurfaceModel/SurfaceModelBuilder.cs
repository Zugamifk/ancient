using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MeshGenerator
{
    public class SurfaceModelBuilder
    {
        SurfaceModel _model;

        public SurfaceModelBuilder(SurfaceModel model) => _model = model;

        public SurfaceModelBuilder AddPoint(Vector3 point)
        {
            var v = new Vertex();
            v.Position = point;
            _model.Vertices.Add(v);
            return this;
        }

        public SurfaceModelBuilder ConnectPoints(int v1, int v2)
        {
            var edge = new Edge();
            _model.Edges.Add(edge);

            var h1 = new HalfEdge();
            _model.HalfEdges.Add(h1);
            var h2 = new HalfEdge();
            _model.HalfEdges.Add(h2);

            edge.HalfEdge = h1;

            h1.Edge = edge;
            h1.Twin = h2;

            h2.Edge = edge;
            h2.Twin = h1;

            return this;
        }

        public SurfaceModel Build() => _model;
    }
}
