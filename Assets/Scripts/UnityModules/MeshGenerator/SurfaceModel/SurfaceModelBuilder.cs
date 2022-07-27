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
            v.Label = $"V{_model.Vertices.Count}";
            _model.Vertices.Add(v);
            return v;
        }

        public Face CreateFace(params Vertex[] points)
        {
            var face = new Face();

            for (int i = 0; i < points.Length; i++)
            {
                var p0 = points[(i - 1 + points.Length) % points.Length];
                var p1 = points[i];
                var p2 = points[(i + 1) % points.Length];
                var h0 = p0.HalfEdges().FirstOrDefault(h => h.To == p1);
                var h1 = p1.HalfEdges().FirstOrDefault(h => h.To == p2);
                if(h0.Next!=h1)
                {
                    SetNext(h0, h1);
                }
                h0.Face = face;
                face.HalfEdge = h0;
            }

            _model.Faces.Add(face);

            return face;
        }

        void SetNext(HalfEdge h1, HalfEdge h2)
        {
            throw new NotImplementedException();
        }

        public Edge ConnectPoints(int a, int b)
        {
            return ConnectPoints(_model.Vertices[a], _model.Vertices[b]);
        }

        public Edge ConnectPoints(Vertex v1, Vertex v2)
        {
            var h1 = CreateHalfEdge(v1);
            var h2 = CreateHalfEdge(v2);
            var edge = CreateEdge(h1, h2);

            var from = v1.HalfEdges().FirstOrDefault(he => he.Face == h1.Face && he.Vertex != v1);
            if (from != null)
            {
                var to = from.Next;
                from.Next = h1;
                h2.Next = to;
            }

            from = v2.HalfEdges().FirstOrDefault(he => he.Face == h2.Face && he.Vertex != v2);
            if (from != null)
            {
                var to = from.Next;
                from.Next = h2;
                h1.Next = to;
            }

            v1.HalfEdge = h1;
            v2.HalfEdge = h2;

            return edge;
        }

        HalfEdge CreateHalfEdge(Vertex vertex)
        {
            var h = new HalfEdge();
            h.Label = $"H{_model.HalfEdges.Count}";
            h.Vertex = vertex;
            h.Face = Face.Outside;
            _model.HalfEdges.Add(h);
            return h;
        }

        Edge CreateEdge(HalfEdge h1, HalfEdge h2)
        {
            var edge = new Edge();
            edge.Label = $"E{_model.Edges.Count}";
            edge.HalfEdge = h1;
            _model.Edges.Add(edge);

            h1.Edge = edge;
            h1.Twin = h2;
            h1.Next = h2;

            h2.Edge = edge;
            h2.Twin = h1;
            h2.Next = h1;
            return edge;
        }
    }
}
