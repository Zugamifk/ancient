using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MeshGenerator
{
    public interface IGeometryGenerator
    {
        void Generate(MeshBuilder builder, Matrix4x4 matrix);
    }
}
