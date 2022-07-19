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
            _generator.Rotation = EditorGUILayout.FloatField("Rotation", _generator.Rotation);
            _generator.FloorDimensions = EditorGUILayout.Vector2Field("Floor Dimensions", _generator.FloorDimensions);
            _generator.FloorThickness = EditorGUILayout.FloatField("Floor Thickness", _generator.FloorThickness);
        }

        public void DrawSceneGUI(Transform rootTransform)
        {
            Handles.matrix = rootTransform.localToWorldMatrix 
                * Matrix4x4.TRS(
                    new Vector3(0, -_generator.FloorThickness/2,0), 
                    Quaternion.AngleAxis(_generator.Rotation, Vector3.up), 
                    new Vector3(_generator.FloorDimensions.x, _generator.FloorThickness, _generator.FloorDimensions.y));
            Handles.DrawWireCube(Vector3.zero, Vector3.one);
        }

        public void SetGenerator(IGeometryGenerator generator)
        {
            _generator = (HouseGenerator)generator;
        }
    }
}
