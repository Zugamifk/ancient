using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MeshGenerator
{
    public class BevelOperation
    {
        class SplitInfo
        {
            public Vertex Base;
            public List<Vertex> Split = new();
        }

        Dictionary<Vertex, SplitInfo> _splitVertexLookup = new();


        public void BevelEdges(float amount, params Edge[] edges)
        {
            _splitVertexLookup.Clear();

            foreach (var e in edges)
            {
                SplitEdge(e);
            }

            foreach(var v in _splitVertexLookup.Keys)
            {
                ExplodeVertex(v);
            }
        }

        void SplitEdge(Edge edge)
        {

        }

        void ExplodeVertex(Vertex vertex)
        {

        }
    }
}
