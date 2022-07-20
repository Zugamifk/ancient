using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace MeshGenerator.Editor
{
    [MeshGeneratorEditor(typeof(HouseMeshGeneratorEditor), typeof(HouseGenerator))]
    public class HouseMeshGeneratorEditor : IMeshGeneratorEditor
    {
        HouseGenerator _generator;
        public void DrawInspectorGUI()
        {
            var d = _generator.Data;
            using (var cc = new EditorGUI.ChangeCheckScope())
            {
                d.Rotation = EditorGUILayout.FloatField("Rotation", d.Rotation);
                d.FloorDimensions = EditorGUILayout.Vector2Field("Floor Dimensions", d.FloorDimensions);
                d.FloorThickness = EditorGUILayout.FloatField("Floor Thickness", d.FloorThickness);
                d.Height = EditorGUILayout.FloatField("Height", d.Height);
                if (cc.changed)
                {
                    SceneView.RepaintAll();
                }
            }
        }

        public void DrawSceneGUI(Transform rootTransform)
        {
            var d = _generator.Data;
            Handles.matrix = rootTransform.localToWorldMatrix
                * Matrix4x4.TRS(
                    Vector3.zero,
                    Quaternion.AngleAxis(d.Rotation, Vector3.up),
                    Vector3.one);
            Handles.DrawWireCube(
                new Vector3(0, -d.FloorThickness / 2, 0),
                new Vector3(d.FloorDimensions.x, d.FloorThickness, d.FloorDimensions.y));

            var h = new Vector3(0, d.Height, 0);

            var p0 = new Vector3(-d.FloorDimensions.x / 2, 0, -d.FloorDimensions.y / 2);
            var p1 = new Vector3(-d.FloorDimensions.x / 2, 0, d.FloorDimensions.y / 2);
            var p2 = new Vector3(d.FloorDimensions.x / 2, 0, -d.FloorDimensions.y / 2);
            var p3 = new Vector3(d.FloorDimensions.x / 2, 0, d.FloorDimensions.y / 2);

            Handles.DrawLine(p0, p0 + h);
            Handles.DrawLine(p1, p1 + h);
            Handles.DrawLine(p2, p2 + h);
            Handles.DrawLine(p3, p3 + h);
        }

        public void SetGenerator(IGeometryGenerator generator)
        {
            _generator = (HouseGenerator)generator;
        }
    }
}
