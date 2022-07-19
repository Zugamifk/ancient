using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace MeshGenerator.Editor
{
    public class HouseMeshGeneratorEditor : IMeshGeneratorEditor
    {
        HouseMeshGenerator _generator;
        public void DrawInspectorGUI()
        {
            _generator.Rotation = EditorGUILayout.FloatField("Rotation", _generator.Rotation);
            _generator.FloorDimensions = EditorGUILayout.Vector2Field("Floor Dimensions", _generator.FloorDimensions);
            _generator.FloorThickness = EditorGUILayout.FloatField("Floor Thickness", _generator.FloorThickness);
        }

        public void DrawSceneGUI(Transform rootTransform)
        {
        }

        public void SetGenerator(IMeshGenerator generator)
        {
            _generator = (HouseMeshGenerator)generator;
        }
    }
}
