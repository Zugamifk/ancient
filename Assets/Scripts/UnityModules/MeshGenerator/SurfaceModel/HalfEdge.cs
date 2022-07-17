using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MeshGenerator
{
    public class HalfEdge
    {
        public HalfEdge Twin;
        public HalfEdge Next;
        public Vertex Vertex;
        public Edge Edge;
        public Face Face;

        public Vertex From => Vertex;
        public Vertex To => Twin.From;
    }
}
