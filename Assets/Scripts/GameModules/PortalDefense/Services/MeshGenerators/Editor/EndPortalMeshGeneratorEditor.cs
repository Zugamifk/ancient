using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MeshGenerator.Editor;
using MeshGenerator;
using UnityEditor;

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
            WireframeDrawer.Draw(_generator.Wireframe);
        }

        public void SetGenerator(IGeometryGenerator generator)
        {
            _generator = (EndPortalMeshGenerator)generator;
            _generator.BuildWireframe();
        }
    }
}
