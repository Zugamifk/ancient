using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using MeshGenerator.Wireframe;
using System;

namespace MeshGenerator.Editor
{
    [MeshGeneratorEditor(typeof(HouseMeshGeneratorEditor), typeof(HouseGenerator))]
    public class HouseMeshGeneratorEditor : IMeshGeneratorEditor
    {
        HouseGenerator _generator;
        Frame _wireframe;
        IPoint[] _wallCorners;

        void BuildWireframe()
        {
            _wireframe = new();
            var d = _generator.Data;
            
            // base
            float fx() => d.FloorDimensions.x / 2 + d.BaseExtents;
            float fy() => d.FloorDimensions.y / 2 + d.BaseExtents;

            var b0 = new DynamicPoint(() => new Vector3(-fx(), 0, -fy()));
            var b1 = new DynamicPoint(() => new Vector3(-fx(), 0, fy()));
            var b2 = new DynamicPoint(() => new Vector3(fx(), 0, fy()));
            var b3 = new DynamicPoint(() => new Vector3(fx(), 0, -fy()));

            _wireframe.Connect(b0, b1);
            _wireframe.Connect(b1, b2);
            _wireframe.Connect(b2, b3);
            _wireframe.Connect(b3, b0);

            // walls
            var h = new Vector3(0, d.Height, 0);
            float bx() => d.FloorDimensions.x / 2;
            float by() => d.FloorDimensions.y / 2;
            var w0 = new DynamicPoint(() => new Vector3(-bx(), 0, -by()));
            var w1 = new DynamicPoint(() => new Vector3(-bx(), 0, by()));
            var w2 = new DynamicPoint(() => new Vector3(bx(), 0, by()));
            var w3 = new DynamicPoint(() => new Vector3(bx(), 0, -by()));
            _wallCorners = new[] { w0, w1, w2, w3 };

            _wireframe.Connect(w0, w1);
            _wireframe.Connect(w1, w2);
            _wireframe.Connect(w2, w3);
            _wireframe.Connect(w3, w0);

            var w4 = new DynamicPoint(() => w0.Position + Vector3.up * d.Height);
            var w5 = new DynamicPoint(() => Vector3.Lerp(w0.Position, w1.Position, .5f) + Vector3.up * (d.Height + d.RoofPeak));
            var w6 = new DynamicPoint(() => w1.Position + Vector3.up * d.Height);
            var w7 = new DynamicPoint(() => w2.Position + Vector3.up * d.Height);
            var w8 = new DynamicPoint(() => Vector3.Lerp(w2.Position, w3.Position, .5f) + Vector3.up * (d.Height + d.RoofPeak));
            var w9 = new DynamicPoint(() => w3.Position + Vector3.up * d.Height);

            _wireframe.Connect(w0, w4);
            _wireframe.Connect(w1, w6);
            _wireframe.Connect(w2, w7);
            _wireframe.Connect(w3, w9);

            _wireframe.Connect(w4, w5);
            _wireframe.Connect(w5, w6);
            _wireframe.Connect(w6, w7);
            _wireframe.Connect(w7, w8);
            _wireframe.Connect(w8, w9);
            _wireframe.Connect(w9, w4);

            // roof
            var rd = (w2.Position - w1.Position).normalized;

            var r0 = new DynamicPoint(() => w4.Position - rd * d.EavesLength);
            var r1 = new DynamicPoint(() => w5.Position - rd * d.EavesLength);
            var r2 = new DynamicPoint(() => w6.Position - rd * d.EavesLength);
            var r3 = new DynamicPoint(() => w7.Position + rd * d.EavesLength);
            var r4 = new DynamicPoint(() => w8.Position + rd * d.EavesLength);
            var r5 = new DynamicPoint(() => w9.Position + rd * d.EavesLength);

            _wireframe.Connect(r0, r1);
            _wireframe.Connect(r1, r2);
            _wireframe.Connect(r2, r3);
            _wireframe.Connect(r3, r4);
            _wireframe.Connect(r4, r5);
            _wireframe.Connect(r5, r0);
            _wireframe.Connect(r1, r4);

            // windows
            for (int i = 0; i < 4; i++)
            {
                var w = d.Walls[i];
                var wp0 = _wallCorners[i];
                var wp1 = _wallCorners[(i + 1) % 4];
                Func<Vector3> wd = () =>
                {
                    return (wp1.Position - wp0.Position).normalized;
                };

                for (int j=0;j<w.Windows.Count;j++)
                {
                    var window = w.Windows[j];
                    var ww0 = new DynamicPoint(() => Vector3.Lerp(wp1.Position - wd() * window.Dimensions.x, wp0.Position, window.Position) + Vector3.up * d.WindowHeight);
                    var ww1 = new DynamicPoint(() => ww0.Position + Vector3.up * window.Dimensions.y);
                    var ww2 = new DynamicPoint(() => ww0.Position + Vector3.up * window.Dimensions.y + wd() * window.Dimensions.x);
                    var ww3 = new DynamicPoint(() => ww0.Position + wd() * window.Dimensions.x);

                    _wireframe.Connect(ww0, ww1);
                    _wireframe.Connect(ww1, ww2);
                    _wireframe.Connect(ww2, ww3);
                    _wireframe.Connect(ww3, ww0);
                }
            }

            // door
            Func<Vector3> dir = () =>
            {
                var di = d.Door.Wall;
                var wp0 = _wallCorners[di].Position;
                var wp1 = _wallCorners[(di + 1) % 4].Position;
                return (wp1 - wp0).normalized;
            };
            var d0 = new DynamicPoint(() =>
            {
                var di = d.Door.Wall;
                var wp0 = _wallCorners[di].Position;
                var wp1 = _wallCorners[(di + 1) % 4].Position;
                return Vector3.Lerp(wp1 - dir() * d.Door.Dimensions.x, wp0 , d.Door.Position);
            });
            var d1 = new DynamicPoint(() => d0.Position + Vector3.up * d.Door.Dimensions.y);
            var d2 = new DynamicPoint(() => d1.Position + dir()*d.Door.Dimensions.x);
            var d3 = new DynamicPoint(() => d0.Position + dir()*d.Door.Dimensions.x);

            _wireframe.Connect(d0, d1);
            _wireframe.Connect(d1, d2);
            _wireframe.Connect(d2, d3);
        }

        public void DrawInspectorGUI()
        {
            var d = _generator.Data;

            bool rebuildWireframe = false;

            EditorGUI.BeginChangeCheck();

            EditorGUILayout.LabelField("General", EditorStyles.boldLabel);
            d.Rotation = EditorGUILayout.FloatField("Rotation", d.Rotation);
            d.FloorDimensions = EditorGUILayout.Vector2Field("Floor Dimensions", d.FloorDimensions);
            d.BaseExtents = EditorGUILayout.FloatField("Wall Inset", d.BaseExtents);
            d.Height = EditorGUILayout.FloatField("Height", d.Height);
            d.WindowHeight = EditorGUILayout.FloatField("Window Height", d.WindowHeight);
            d.RoofPeak = EditorGUILayout.FloatField("Roof Peak", d.RoofPeak);
            d.EavesLength = EditorGUILayout.FloatField("Eaves Length", d.EavesLength);

            EditorGUILayout.Space(10);
            EditorGUILayout.LabelField("Walls", EditorStyles.boldLabel);

            for (int i = 0; i < 4; i++)
            {
                EditorGUILayout.LabelField("Wall "+i, EditorStyles.boldLabel);
                var wall = d.Walls[i];
                var windowCount = wall.Windows.Count;
                EditorGUILayout.LabelField("Windows", EditorStyles.boldLabel);
                int newWindowCount = EditorGUILayout.IntField("Count", windowCount);
                if (windowCount != newWindowCount)
                {
                    if (windowCount > newWindowCount)
                    {
                        wall.Windows.RemoveRange(newWindowCount, windowCount - newWindowCount);
                    } else
                    {
                        for(int j=windowCount;j<newWindowCount;j++)
                        {
                            wall.Windows.Add(new HouseGenerator.GeometryData.WindowData());
                        }
                    }
                    rebuildWireframe = true;
                }
                for (int j=0;j<wall.Windows.Count;j++)
                {
                    EditorGUILayout.LabelField("Window "+j, EditorStyles.boldLabel);
                    var window = wall.Windows[j];
                    window.Dimensions = EditorGUILayout.Vector2Field("Dimensions", window.Dimensions);
                    window.Position = EditorGUILayout.Slider("Position", window.Position, 0, 1);
                }
                EditorGUILayout.Space(5);
            }

            d.Door.Dimensions = EditorGUILayout.Vector2Field("Door Dimensions", d.Door.Dimensions);
            d.Door.Position = EditorGUILayout.Slider("Door Position", d.Door.Position, 0, 1);
            d.Door.Wall = EditorGUILayout.IntSlider("Door Wall", d.Door.Wall, 0, 3);

            if (EditorGUI.EndChangeCheck())
            {
                EditorUtility.SetDirty(d);
            }

            if (rebuildWireframe)
            {
                BuildWireframe();
            }
        }

        public void DrawSceneGUI(Transform rootTransform)
        {
            Handles.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.AngleAxis(_generator.Data.Rotation, Vector3.up), Vector3.one);
            WireframeDrawer.Draw(_wireframe);
        }

        public void SetGenerator(IGeometryGenerator generator)
        {
            _generator = (HouseGenerator)generator;
            BuildWireframe();
        }
    }
}
