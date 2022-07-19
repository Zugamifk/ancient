using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MeshGenerator
{
    public class MeshBuilder
    {
        MeshData _data = new();

        public void AddPoint(Vector3 position, Vector3 normal = default, Color color = default)
        {
            _data.Vertices.Add(position);
            _data.Normals.Add(normal);
            _data.Colors.Add(color);
        }

        public void AddTriangle(int i0, int i1, int i2)
        {
            _data.Triangles.Add(i0);
            _data.Triangles.Add(i1);
            _data.Triangles.Add(i2);
        }

        public void AddTriangle(Vector3 p0, Vector3 p1, Vector3 p2, Color color = default)
        {
            var n = Vector3.Cross(p1 - p0, p2 - p0).normalized;
            var i = _data.Vertices.Count;
            AddPoint(p0, n, color);
            AddPoint(p1, n, color);
            AddPoint(p2, n, color);
            AddTriangle(i, i + 1, i + 2);
        }

        public void AddQuad(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, Color color = default)
        {
            var n = Vector3.Cross(p1 - p0, p2 - p0).normalized;
            var i = _data.Vertices.Count;
            AddPoint(p0, n, color);
            AddPoint(p1, n, color);
            AddPoint(p2, n, color);
            AddPoint(p3, n, color);
            AddTriangle(i, i + 1, i + 2);
            AddTriangle(i, i + 2, i + 3);
        }

        public void Generate(IGeometryGenerator generator, Matrix4x4 matrix)
        {
            generator.Generate(this, matrix);
        }

        public Mesh Build(MeshGeneratorContext context)
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
