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

            //for (int i = 0; i < points.Length; i++)
            //{
            //    var he = CreateHalfEdge(points[i], points[i % points.Length]);
            //    he.Vertex = points[i];
            //    he.Face = face;

            //    points[i].HalfEdge = he;

            //    if (i > 0)
            //    {
            //        var last = points[i - 1].HalfEdge;
            //        last.Next = he;
            //    }
            //}
            //points[points.Length - 1].HalfEdge.Next = points[0].HalfEdge;

            //face.HalfEdge = points[0].HalfEdge;

            _model.Faces.Add(face);

            return face;
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
