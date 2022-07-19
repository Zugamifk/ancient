using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MeshGenerator
{
    public class HouseMeshGenerator : IMeshGenerator
    {
        public float Rotation;

        public Vector2 FloorDimensions;
        public float FloorThickness;

        CubeMeshGenerator _cubeGenerator = new();

        public Mesh Generate(MeshGeneratorContext context)
        {
        }
    }
}
