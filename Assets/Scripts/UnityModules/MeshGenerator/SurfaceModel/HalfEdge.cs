using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MeshGenerator
{
    public class HalfEdge
    {
        public string Label;
        public HalfEdge Twin;
        public HalfEdge Next;
        public Vertex Vertex;
        public Edge Edge;
        public Face Face;

        public Vertex From => Vertex;
        public Vertex To => Twin.From;

        public override string ToString()
        {
            return $"{Label} -> {Next.Label} [Twin: {Twin.Label}]";
        }
    }
}
