using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MeshGenerator
{
    public class SurfaceModel
    {
        public List<Vertex> Vertices = new();
        public List<HalfEdge> HalfEdges = new();
        public List<Edge> Edges = new();
        public List<Face> Faces = new();
    }
}
