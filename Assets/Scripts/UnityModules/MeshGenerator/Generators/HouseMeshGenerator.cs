using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MeshGenerator
{
    public class HouseGenerator : IGeometryGenerator
    {
        public float Rotation;

        public Vector2 FloorDimensions;
        public float FloorThickness;

        CubeGenerator _cubeGenerator = new();

        public void Generate(MeshBuilder builder, Matrix4x4 matrix)
        {
            throw new System.NotImplementedException();
        }
    }
}
