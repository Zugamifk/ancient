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

        public Edge ConnectPoints(int i1, int i2)
        {
            return ConnectPoints(_model.Vertices[i1], _model.Vertices[i2]);
        }

        public Edge ConnectPoints(Vertex v1, Vertex v2)
        {
            var edge = new Edge();
            edge.Label = $"E{_model.Edges.Count}";
            _model.Edges.Add(edge);

            var h1 = new HalfEdge();
            h1.Label = $"H{_model.HalfEdges.Count}";
            h1.Vertex = v1;
            h1.Face = Face.Outside;
            _model.HalfEdges.Add(h1);

            var h2 = new HalfEdge();
            h2.Label = $"H{_model.HalfEdges.Count}";
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

            var from = v1.HalfEdges().FirstOrDefault(he=>he.Face == h1.Face && he.Vertex!=v1);
            if (from != null)
            {
                from.Next = h1;
            }

            from = v2.HalfEdges().FirstOrDefault(he => he.Face == h2.Face && he.Vertex != v2);
            if (from != null)
            {
                from.Next = h2;
            }

            var to = v1.HalfEdges().FirstOrDefault(he => he.Face == h1.Face && he.Vertex == v1);
            if (to != null)
            {
                h2.Next = to;
            }

            to = v2.HalfEdges().FirstOrDefault(he => he.Face == h2.Face && he.Vertex == v2);
            if (to != null)
            {
                h1.Next = to;
            }

            v1.HalfEdge = h1;
            v2.HalfEdge = h2;

            return edge;
        }

        public Face CreateFace(HalfEdge startEdge)
        {
            if(startEdge.Next.Edge == startEdge.Edge)
            {
                throw new InvalidOperationException($"Error creating face! Half edge loops onto same edge!");
            }

            var start = startEdge;
            var he = start;
            var face = new Face();
            do
            {
                he.Face = face;
                he = he.Next;
            } while (he != start);
            face.HalfEdge = startEdge;

            _model.Faces.Add(face);

            return face;
        }
    }
}
