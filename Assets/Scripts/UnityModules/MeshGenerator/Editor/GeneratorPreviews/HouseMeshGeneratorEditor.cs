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
            d.WallInset = EditorGUILayout.FloatField("Wall Inset", d.WallInset);
            d.Height = EditorGUILayout.FloatField("Height", d.Height);
            d.RoofPeak = EditorGUILayout.FloatField("Roof Peak", d.RoofPeak);
        }

        public void DrawSceneGUI(Transform rootTransform)
        {
            var d = _generator.Data;
            Handles.matrix = rootTransform.localToWorldMatrix
                * Matrix4x4.TRS(
                    Vector3.zero,
                    Quaternion.AngleAxis(d.Rotation, Vector3.up),
                    Vector3.one);

            var bx = d.FloorDimensions.x;
            var by = d.FloorDimensions.y;
            Handles.DrawWireCube(
                new Vector3(0, -d.FloorThickness / 2, 0),
                new Vector3(bx, d.FloorThickness, by));

            var h = new Vector3(0, d.Height, 0);
            var cx = bx / 2 - d.WallInset;
            var cy = by / 2 - d.WallInset;
            var p0 = new Vector3(-cx, 0, -cy);
            var p1 = new Vector3(-cx, 0, cy);
            var p2 = new Vector3(cx, 0, cy);
            var p3 = new Vector3(cx, 0, -cy);

            Handles.DrawLine(p0, p0 + h);
            Handles.DrawLine(p1, p1 + h);
            Handles.DrawLine(p2, p2 + h);
            Handles.DrawLine(p3, p3 + h);

            Handles.DrawLine(p0, p1);
            Handles.DrawLine(p1, p2);
            Handles.DrawLine(p2, p3);
            Handles.DrawLine(p3, p0);

            Handles.DrawLine(p0 + h, p3 + h);
            Handles.DrawLine(p1 + h, p2 + h);

            var r = new Vector3(0, d.RoofPeak, 0);
            var r0 = Vector3.Lerp(p0, p1, .5f) + h + r;
            var r1 = Vector3.Lerp(p2, p3, .5f) + h + r;

            Handles.DrawLine(p0 + h, r0);
            Handles.DrawLine(p1 + h, r0);
            Handles.DrawLine(p2 + h, r1);
            Handles.DrawLine(p3 + h, r1);
            Handles.DrawLine(r0, r1);
        }

        public void SetGenerator(IGeometryGenerator generator)
        {
            _generator = (HouseGenerator)generator;
        }
    }
}
