using System;
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

        public Face CreateFace(params int[] indices)
        {
            return CreateFace(indices.Select(i => _model.Vertices[i]).ToArray());
        }

        public Face CreateFace(params Vertex[] points)
        {
            var face = new Face();

            for (int i = 0; i < points.Length; i++)
            {
                var p0 = points[(i - 1 + points.Length) % points.Length];
                var p1 = points[i];
                var p2 = points[(i + 1) % points.Length];
                var h0 = GetHalfEdge(p0, p1);
                var h1 = GetHalfEdge(p1, p2);
                if (h0.Next!=h1)
                {
                    SetNext(h0, h1);
                }
                h0.Face = face;
                face.HalfEdge = h0;
            }

            _model.Faces.Add(face);

            return face;
        }

        HalfEdge GetHalfEdge(Vertex from, Vertex to)
        {
            var  h = from.HalfEdges().FirstOrDefault(h => h.EndVertex == to);
            if(h == null)
            {
                h = ConnectPoints(from, to).HalfEdge;
            }
            return h;
        }

        void SetNext(HalfEdge h1, HalfEdge h2)
        {
            var prev = h2.Previous;
            var next = h1.Next;
            h1.Next = h2;
            prev.Next = next;
        }

        public Edge ConnectPoints(int a, int b)
        {
            return ConnectPoints(_model.Vertices[a], _model.Vertices[b]);
        }

        public Edge ConnectPoints(Vertex v1, Vertex v2)
        {
            Debug.Log($"Connect {v1} to {v2}");
            var h1 = CreateHalfEdge(v1);
            var h2 = CreateHalfEdge(v2);
            var edge = CreateEdge(h1, h2);

            var from = v1.EnteringHalfEdges().FirstOrDefault(he => he.Face == h1.Face);
            if (from != null)
            {
                var to = from.Next;
                from.Next = h1;
                h2.Next = to;
            } else
            {
                Debug.LogWarning($"No half eadge leading to {h1}!");
            }

            from = v2.EnteringHalfEdges().FirstOrDefault(he => he.Face == h2.Face);
            if (from != null)
            {
                var v2next = from.Next;
                var v1next = h1.Next;
                from.Next = h2;
                h1.Next = v2next;
            }
            else
            {
                Debug.LogWarning($"No half eadge leading to {h2}!");
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

        public void RemoveEdge(Edge edge)
        {
            var left = edge.HalfEdge;
            var right = left.Twin;

            var fl = left.Face;
            var fr = right.Face;
            foreach(var he in right.Loop())
            {
                he.Face = fl;
            }
            _model.Faces.Remove(fr);

            var lp = left.Previous;
            var rp = right.Previous;
            lp.Next = right.Next;
            rp.Next = left.Next;

            _model.Edges.Remove(edge);
            _model.HalfEdges.Remove(left);
            _model.HalfEdges.Remove(right);
        }
    }
}
