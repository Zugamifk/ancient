using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MeshGenerator.Wireframe
{
    public class Frame
    {
        public List<IPoint> Points = new();
        public List<Edge> Edges = new();

        public void Connect(IPoint a, IPoint b)
        {
            Edges.Add(new Edge() { A = a, B = b });
        }

        public void Prism(IPoint baseCentre, Func<float> height, int sides, Func<float> radius, Vector3 direction)
        {
            var rot = Quaternion.identity;
            var step = Quaternion.AngleAxis(360 / (float)sides, direction);
            Func<Vector3> baseDir = () => Vector3.Cross(new Vector3(.5f, 0, .5f), direction).normalized * radius();
            for (int i = 0; i < sides; i++)
            {
                var cr = rot;
                Func<Vector3> p0 = () => baseCentre.Position + cr * baseDir();
                Func<Vector3> p1 = () => baseCentre.Position + step * cr * baseDir();
                Connect(new DynamicPoint(p0), new DynamicPoint(p1));
                Func<Vector3> p2 = () => p0() + direction * height();
                Connect(new DynamicPoint(p0), new DynamicPoint(p2));
                Func<Vector3> p3 = () => p1() + direction * height();
                Connect(new DynamicPoint(p2), new DynamicPoint(p3));
                rot *= step;
            }
        }
    }
}
