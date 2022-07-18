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

        static HashSet<HalfEdge> _visited = new();
        public IEnumerable<HalfEdge> Loop()
        {
            _visited.Clear();
            var start = this;
            var next = start;
            do
            {
                yield return next;
                _visited.Add(next);
                next = next.Next;

                if (next == start)
                {
                    yield break;
                }
            } while (!_visited.Contains(next));

            throw new System.InvalidOperationException($"Error enumerating loop! Found an internal loop at {next}");
        }

        public override string ToString()
        {
            return $"{Label} -> {Next.Label} [Twin: {Twin.Label}]";
        }
    }
}
