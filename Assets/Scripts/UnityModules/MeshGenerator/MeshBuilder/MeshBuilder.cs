using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MeshGenerator
{
    public class MeshBuilder
    {
        MeshData _data = new();
        Color _currentColor;

        Stack<Matrix4x4> _matrixStack = new();
        Matrix4x4 _matrix;

        public MeshBuilder()
        {
            _matrix = Matrix4x4.identity;
        }

        public void PushMatrix(Matrix4x4 matrix)
        {
            _matrixStack.Push(matrix);
            _matrix *= matrix;
        }

        public void PopMatrix()
        {
            var matrix = _matrixStack.Pop();
            _matrix *= matrix.inverse;
        }

        public void SetColor(Color color)
        {
            _currentColor = color;
        }

        public void AddPoint(Vector3 position, Vector3 normal = default)
        {
            position = _matrix.MultiplyPoint3x4(position);
            normal = _matrix.MultiplyVector(normal);
            _data.Vertices.Add(position);
            _data.Normals.Add(normal);
            _data.Colors.Add(_currentColor);
        }

        public void AddTriangle(int i0, int i1, int i2)
        {
            _data.Triangles.Add(i0);
            _data.Triangles.Add(i1);
            _data.Triangles.Add(i2);
        }

        public void AddTriangle(Vector3 p0, Vector3 p1, Vector3 p2)
        {
            var n = Vector3.Cross(p1 - p0, p2 - p0).normalized;
            var i = _data.Vertices.Count;
            AddPoint(p0, n);
            AddPoint(p1, n);
            AddPoint(p2, n);
            AddTriangle(i, i + 1, i + 2);
        }

        public void AddQuad(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3)
        {
            var n = Vector3.Cross(p1 - p0, p2 - p0).normalized;
            var i = _data.Vertices.Count;
            AddPoint(p0, n);
            AddPoint(p1, n);
            AddPoint(p2, n);
            AddPoint(p3, n);
            AddTriangle(i, i + 1, i + 2);
            AddTriangle(i, i + 2, i + 3);
        }

        public void AddPolygon(params Vector3[] points)
        {
            AddPolygon(points);
        }

        public void AddPolygon(IList<Vector3> points)
        {
            if (points.Count < 3)
            {
                throw new System.ArgumentException("Must have at least 3 points!! Poitns: " + points.Count);
            }

            var n = Vector3.Cross(points[1] - points[0], points[2] - points[0]).normalized;
            var ti = _data.Vertices.Count;
            for (int i = 0; i < points.Count; i++)
            {
                AddPoint(points[i], n);
                if (i > 1)
                {
                    AddTriangle(ti, ti + i - 1, ti + i);
                }
            }
        }

        public void Generate(IGeometryGenerator generator)
        {
            generator.Generate(this);
        }

        public Mesh BuildMesh()
        {
            return new Mesh()
            {
                vertices = _data.Vertices.ToArray(),
                normals = _data.Normals.ToArray(),
                colors = _data.Colors.ToArray(),
                triangles = _data.Triangles.ToArray()
            };
        }
    }
}
