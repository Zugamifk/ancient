using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using MeshGenerator.Wireframe;

namespace MeshGenerator.Editor
{
    [MeshGeneratorEditor(typeof(HouseMeshGeneratorEditor), typeof(HouseGenerator))]
    public class HouseMeshGeneratorEditor : IMeshGeneratorEditor
    {
        HouseGenerator _generator;
        Frame _wireframe;

        void BuildWireframe()
        {
            _wireframe = new();
            var d = _generator.Data;
            float bx() => d.FloorDimensions.x;
            float by() => d.FloorDimensions.y;

            var b0 = new DynamicPoint(() => new Vector3(-bx(), 0, -by()));
            var b1 = new DynamicPoint(() => new Vector3(-bx(), 0, by()));
            var b2 = new DynamicPoint(() => new Vector3(bx(), 0, by()));
            var b3 = new DynamicPoint(() => new Vector3(bx(), 0, -by()));

            // base
            _wireframe.Connect(b0, b1);
            _wireframe.Connect(b1, b2);
            _wireframe.Connect(b2, b3);
            _wireframe.Connect(b3, b0);

            var h = new Vector3(0, d.Height, 0);
            var cx = bx() / 2 - d.WallInset;
            var cy = by() / 2 - d.WallInset;
            var p0 = new Vector3(-cx, 0, -cy);
            var p1 = new Vector3(-cx, 0, cy);
            var p2 = new Vector3(cx, 0, cy);
            var p3 = new Vector3(cx, 0, -cy);

            Debug.Log("Generated");
        }

        public void DrawInspectorGUI()
        {
            var d = _generator.Data;

            d.Rotation = EditorGUILayout.FloatField("Rotation", d.Rotation);
            d.FloorDimensions = EditorGUILayout.Vector2Field("Floor Dimensions", d.FloorDimensions);
            d.WallInset = EditorGUILayout.FloatField("Wall Inset", d.WallInset);
            d.Height = EditorGUILayout.FloatField("Height", d.Height);
            d.RoofPeak = EditorGUILayout.FloatField("Roof Peak", d.RoofPeak);
            d.EavesLength = EditorGUILayout.FloatField("Eaves Length", d.EavesLength);
            for (int i = 0; i < 4; i++)
            {
                var w = d.Walls[i];
                w.DoorPosition = EditorGUILayout.Slider("Door Position", w.DoorPosition, 0, 1);
                w.DoorWidth = EditorGUILayout.FloatField("Door Width", w.DoorWidth);
                w.DoorHeight = EditorGUILayout.FloatField("Door Height", w.DoorHeight);
            }

        }

        public void DrawSceneGUI(Transform rootTransform)
        {
            WireframeDrawer.Draw(_wireframe);
            //var d = _generator.Data;
            //Handles.matrix = rootTransform.localToWorldMatrix
            //    * Matrix4x4.TRS(
            //        Vector3.zero,
            //        Quaternion.AngleAxis(d.Rotation, Vector3.up),
            //        Vector3.one);

            //var bx = d.FloorDimensions.x;
            //var by = d.FloorDimensions.y;
            //Handles.DrawWireCube(
            //    new Vector3(0, -d.FloorThickness / 2, 0),
            //    new Vector3(bx, d.FloorThickness, by));

            //var h = new Vector3(0, d.Height, 0);
            //var cx = bx / 2 - d.WallInset;
            //var cy = by / 2 - d.WallInset;
            //var p0 = new Vector3(-cx, 0, -cy);
            //var p1 = new Vector3(-cx, 0, cy);
            //var p2 = new Vector3(cx, 0, cy);
            //var p3 = new Vector3(cx, 0, -cy);

            //Handles.DrawLine(p0, p0 + h);
            //Handles.DrawLine(p1, p1 + h);
            //Handles.DrawLine(p2, p2 + h);
            //Handles.DrawLine(p3, p3 + h);

            //Handles.DrawLine(p0, p1);
            //Handles.DrawLine(p1, p2);
            //Handles.DrawLine(p2, p3);
            //Handles.DrawLine(p3, p0);


            //Handles.DrawLine(p0 + h, p3 + h);
            //Handles.DrawLine(p1 + h, p2 + h);

            //var pr = new Vector3(0, d.RoofPeak, 0);
            //var pr0 = Vector3.Lerp(p0, p1, .5f) + h + pr;
            //var pr1 = Vector3.Lerp(p2, p3, .5f) + h + pr;

            //Handles.DrawLine(p0 + h, pr0);
            //Handles.DrawLine(p1 + h, pr0);
            //Handles.DrawLine(p2 + h, pr1);
            //Handles.DrawLine(p3 + h, pr1);

            //var r0 = pr0 - new Vector3(d.EavesLength, 0, 0);
            //var r1 = pr1 + new Vector3(d.EavesLength, 0, 0);
            //var rd0 = (h + p0 - pr0);
            //var rd1 = (h + p1 - pr0);
            //var rp0 = r0 + rd0 + rd0.normalized * d.EavesLength;
            //var rp1 = r0 + rd1 + rd1.normalized * d.EavesLength;
            //var rp2 = r1 + rd1 + rd1.normalized * d.EavesLength;
            //var rp3 = r1 + rd0 + rd0.normalized * d.EavesLength;

            //Handles.DrawLine(r0, r1);
            //Handles.DrawLine(rp0, r0);
            //Handles.DrawLine(rp1, r0);
            //Handles.DrawLine(rp2, r1);
            //Handles.DrawLine(rp3, r1);
            //Handles.DrawLine(rp1, rp2);
            //Handles.DrawLine(rp3, rp0);

            //void DrawDoor(HouseGenerator.GeometryData.WallData wall, Vector3 p0, Vector3 p1)
            //{
            //    var dd = (p1 - p0).normalized;
            //    var d0 = Vector3.Lerp(p0, p1 - dd * wall.DoorWidth, wall.DoorPosition);
            //    var d1 = d0 + new Vector3(0, wall.DoorHeight, 0);
            //    var d2 = d1 + dd * wall.DoorWidth;
            //    var d3 = d0 + dd * wall.DoorWidth;

            //    Handles.DrawLine(d0, d1);
            //    Handles.DrawLine(d1, d2);
            //    Handles.DrawLine(d2, d3);
            //}

            //DrawDoor(d.Walls[0], p0, p1);
            //DrawDoor(d.Walls[1], p1, p2);
            //DrawDoor(d.Walls[2], p2, p3);
            //DrawDoor(d.Walls[3], p3, p0);
        }

        public void SetGenerator(IGeometryGenerator generator)
        {
            _generator = (HouseGenerator)generator;
            BuildWireframe();
        }
    }
}
