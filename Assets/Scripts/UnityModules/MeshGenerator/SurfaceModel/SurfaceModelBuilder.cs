using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MeshGenerator
{
    public class SurfaceModelBuilder
    {
        SurfaceModel _model;

        public SurfaceModelBuilder(SurfaceModel model) => _model = model;

        public Vertex AddPoint(Vector3 point)
        {
            var v = new Vertex();
            v.Position = point;
            _model.Vertices.Add(v);
            return v;
        }

        public Edge ConnectPoints(int i1, int i2)
        {
            return ConnectPoints(_model.Vertices[i1], _model.Vertices[i2]);
        }

        public Edge ConnectPoints(Vertex v1, Vertex v2)
        {
            var edge = new Edge();
            _model.Edges.Add(edge);

            var h1 = new HalfEdge();
            v1.HalfEdge = h1;
            h1.Vertex = v1;
            h1.Face = Face.Outside;
            _model.HalfEdges.Add(h1);

            var h2 = new HalfEdge();
            v2.HalfEdge = h2;
            h2.Vertex = v2;
            h2.Face = Face.Outside;
            _model.HalfEdges.Add(h2);

            edge.HalfEdge = h1;

            h1.Edge = edge;
            h1.Twin = h2;
            h1.Next = h2;

            h2.Edge = edge;
            h2.Twin = h1;
            h2.Next = h1;

            //var from = v1.Edges().FirstOrDefault(e => e.HalfEdge.Face == h1.Face);
            //if (from != null)
            //{
            //    from.HalfEdge.Next = h1;
            //    h2.Next = from.HalfEdge.Twin;
            //}

            //var to = v2.Edges().FirstOrDefault(e => e.HalfEdge.Face == h2.Face);
            //if (to != null)
            //{
            //    h1.Next = to.HalfEdge;
            //    to.HalfEdge.Twin.Next = h2;
            //}

            return edge;
        }
    }
}