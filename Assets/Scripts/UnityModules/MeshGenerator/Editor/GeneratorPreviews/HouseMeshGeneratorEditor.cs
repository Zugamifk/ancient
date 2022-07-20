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
            d.EavesLength = EditorGUILayout.FloatField("Eaves Length", d.EavesLength);
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

            var pr = new Vector3(0, d.RoofPeak, 0);
            var pr0 = Vector3.Lerp(p0, p1, .5f) + h + pr;
            var pr1 = Vector3.Lerp(p2, p3, .5f) + h + pr;

            Handles.DrawLine(p0 + h, pr0);
            Handles.DrawLine(p1 + h, pr0);
            Handles.DrawLine(p2 + h, pr1);
            Handles.DrawLine(p3 + h, pr1);

            var r0 = pr0 - new Vector3(d.EavesLength, 0, 0);
            var r1 = pr1 + new Vector3(d.EavesLength, 0, 0);
            var rd0 = (h + p0 - pr0);
            var rd1 = (h + p1 - pr0);
            var rp0 = r0 + rd0 + rd0.normalized * d.EavesLength;
            var rp1 = r0 + rd1 + rd1.normalized * d.EavesLength;
            var rp2 = r1 + rd1 + rd1.normalized * d.EavesLength;
            var rp3 = r1 + rd0 + rd0.normalized * d.EavesLength;

            Handles.DrawLine(r0, r1);
            Handles.DrawLine(rp0, r0);
            Handles.DrawLine(rp1, r0);
            Handles.DrawLine(rp2, r1);
            Handles.DrawLine(rp3, r1);
            Handles.DrawLine(rp1, rp2);
            Handles.DrawLine(rp3, rp0);
        }

        public void SetGenerator(IGeometryGenerator generator)
        {
            _generator = (HouseGenerator)generator;
        }
    }
}
