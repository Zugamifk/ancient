using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MeshGenerator;
using MeshGenerator.Wireframe;

namespace PortalDefense.View
{
    public class PortalDefenseMeshGeneratorUser : MonoBehaviour
    {
        MeshBuilder _meshBuilder = new();
        protected void AssignMesh<TMeshGenerator>(MeshFilter meshFilter)
            where TMeshGenerator : MeshGenerator.MeshGenerator, new()
        {
            var gen = new TMeshGenerator();
            gen.Generate(_meshBuilder);
            var mesh = _meshBuilder.BuildMesh();
            meshFilter.mesh = mesh;
        }
    }
}
