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
            d.Rotation = EditorGUILayout.FloatField("Rotation", d.Rotation);
            d.FloorDimensions = EditorGUILayout.Vector2Field("Floor Dimensions", d.FloorDimensions);
            d.FloorThickness = EditorGUILayout.FloatField("Floor Thickness", d.FloorThickness);
        }

        public void DrawSceneGUI(Transform rootTransform)
        {
            var d = _generator.Data;
            Handles.matrix = rootTransform.localToWorldMatrix 
                * Matrix4x4.TRS(
                    new Vector3(0, -d.FloorThickness/2,0), 
                    Quaternion.AngleAxis(d.Rotation, Vector3.up), 
                    new Vector3(d.FloorDimensions.x, d.FloorThickness, d.FloorDimensions.y));
            Handles.DrawWireCube(Vector3.zero, Vector3.one);
        }

        public void SetGenerator(IGeometryGenerator generator)
        {
            _generator = (HouseGenerator)generator;
        }
    }
}
