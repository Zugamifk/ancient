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
            var d = _generator.Data;

            EditorGUI.BeginChangeCheck();

            d.Height = EditorGUILayout.FloatField("Height", d.Height);
            d.ColumnSize = EditorGUILayout.FloatField("Column Size", d.ColumnSize);
            d.ColumnSpacing = EditorGUILayout.FloatField("Column Spacing", d.ColumnSpacing);

            if (EditorGUI.EndChangeCheck())
            {
                EditorUtility.SetDirty(d);
            }
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
