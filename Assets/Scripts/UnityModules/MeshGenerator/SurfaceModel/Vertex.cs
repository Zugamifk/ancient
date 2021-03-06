using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MeshGenerator
{
    public class Vertex
    {
        public string Label;
        public Vector3 Position;
        public HalfEdge HalfEdge;

        public IEnumerable<Edge> Edges()
        {
            if (HalfEdge == null) yield break;

            var start = HalfEdge;
            var he = start;
            do
            {
                yield return he.Edge;
                he = he.Twin.Next;
            } while (he != start);
        }

        public IEnumerable<HalfEdge> HalfEdges()
        {
            if (HalfEdge == null) yield break;

            var start = HalfEdge;
            var he = start;
            do
            {
                yield return he;
                yield return he.Twin;
                he = he.Twin.Next;
            } while (he != start);
        }


        public override string ToString()
        {
            return $"{Label} {Position}";
        }
    }
}
