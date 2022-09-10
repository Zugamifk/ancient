using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MeshGenerator.Editor;
using MeshGenerator;
using UnityEditor;

namespace PortalDefense.Services.Editor
{
    [MeshGeneratorEditor(typeof(EnemyMeshGenerator))]
    public class EnemyMeshGeneratorEditor : IMeshGeneratorEditor
    {
        EnemyMeshGenerator _generator;

        public void DrawInspectorGUI()
        {
            var d = _generator.Data;

            EditorGUI.BeginChangeCheck();

            var so = new SerializedObject(d);
            var iter = so.GetIterator();
            if(iter.NextVisible(true))
            {
                iter.NextVisible(false);
                do
                {
                    EditorGUILayout.PropertyField(iter, true);
                }
                while (iter.NextVisible(false));
            }

            if (EditorGUI.EndChangeCheck())
            {
                so.ApplyModifiedProperties();
                EditorUtility.SetDirty(d);
            }
        }

        public void DrawSceneGUI(Transform rootTransform)
        {
            WireframeDrawer.Draw(_generator.Wireframe);
        }

        public void SetGenerator(IGeometryGenerator generator)
        {
            _generator = (EnemyMeshGenerator)generator;
            _generator.BuildWireframe();
        }
    }
}
