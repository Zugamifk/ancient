using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MeshGenerator.Wireframe
{
    public class Wireframe
    {
        public List<IPoint> Points = new();
        public List<Edge> Edges = new();

        public void Connect(IPoint a, IPoint b)
        {
            Edges.Add(new Edge() { A = a, B = b });
        }
    }
}
