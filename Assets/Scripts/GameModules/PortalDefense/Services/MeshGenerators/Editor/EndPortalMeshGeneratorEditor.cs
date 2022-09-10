using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MeshGenerator.Editor;
using MeshGenerator;

namespace PortalDefense.Services.Editor
{
    [MeshGeneratorEditor(typeof(EndPortalMeshGenerator))]
    public class EndPortalMeshGeneratorEditor : IMeshGeneratorEditor
    {
        EndPortalMeshGenerator _generator;

        public void DrawInspectorGUI()
        {
        }

        public void DrawSceneGUI(Transform rootTransform)
        {
        }

        public void SetGenerator(IGeometryGenerator generator)
        {
            _generator = (EndPortalMeshGenerator)generator;
            _generator.BuildWireframe();
        }
    }
}
