using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MeshGenerator;
using MeshGenerator.Wireframe;

namespace PortalDefense.Services
{
    [MeshGenerator("End Portal")]
    public class EndPortalMeshGenerator : IGeometryGenerator
    {
        public class GeometryData : ScriptableObject
        {
            public float Height = 2;
            public float ColumnSpacing = .5f;
            public float ColumnSize = .1f;
            public float RoofThickness = 0.05f;

            public static GeometryData Instance;
            private void OnEnable()
            {
                Instance = this;
            }
        }

        public GeometryData Data => _data;
        public Frame Wireframe => _wireframe;

        static GeometryData _data => GeometryData.Instance;
        Frame _wireframe;

        static EndPortalMeshGenerator()
        {
            if (_data == null)
            {
                ScriptableObject.CreateInstance<GeometryData>();
                _data.hideFlags = HideFlags.HideAndDontSave;
            }
        }

        public void Generate(MeshBuilder builder)
        {
            void AddColumn(float x, float y)
            {
                var b = new Vector3(x, 0, y);
                var p0 = b + new Vector3(-_data.ColumnSize, 0, -_data.ColumnSize);
                var p1 = b + new Vector3(-_data.ColumnSize, 0, _data.ColumnSize);
                var p2 = b + new Vector3(_data.ColumnSize, 0, _data.ColumnSize);
                var p3 = b + new Vector3(_data.ColumnSize, 0, -_data.ColumnSize);
                var p4 = p0 + new Vector3(0, _data.Height, 0);
                var p5 = p1 + new Vector3(0, _data.Height, 0);
                var p6 = p2 + new Vector3(0, _data.Height, 0);
                var p7 = p3 + new Vector3(0, _data.Height, 0);

                builder.AddQuad(p0, p1, p5, p4);
                builder.AddQuad(p1, p2, p6, p5);
                builder.AddQuad(p2, p3, p7, p6);
                builder.AddQuad(p3, p0, p4, p7);
            }

            builder.SetColor(new Color(.75f, .75f, .75f, 1));
            AddColumn(-_data.ColumnSpacing, -_data.ColumnSpacing);
            AddColumn(_data.ColumnSpacing, -_data.ColumnSpacing);
            AddColumn(_data.ColumnSpacing, _data.ColumnSpacing);
            AddColumn(-_data.ColumnSpacing, _data.ColumnSpacing);

            void AddRoofStep(float w, float h)
            {
                var b = new Vector3(0, _data.Height+h, 0);
                var p0 = b + new Vector3(-w, 0, -w);
                var p1 = b + new Vector3(-w, 0, w);
                var p2 = b + new Vector3(w, 0, w);
                var p3 = b + new Vector3(w, 0, -w);
                var p4 = p0 + new Vector3(0, _data.RoofThickness, 0);
                var p5 = p1 + new Vector3(0, _data.RoofThickness, 0);
                var p6 = p2 + new Vector3(0, _data.RoofThickness, 0);
                var p7 = p3 + new Vector3(0, _data.RoofThickness, 0);

                builder.AddQuad(p3, p2, p1, p0);
                builder.AddQuad(p0, p1, p5, p4);
                builder.AddQuad(p1, p2, p6, p5);
                builder.AddQuad(p2, p3, p7, p6);
                builder.AddQuad(p3, p0, p4, p7);
                builder.AddQuad(p4, p5, p6, p7);
            }

            AddRoofStep(.5f, 0);
            AddRoofStep(.4f, _data.RoofThickness);
        }

        public void BuildWireframe()
        {
            _wireframe = new();

            var b = .5f;
            var b0 = new Point(-b, 0, -b);
            var b1 = new Point(-b, 0, b);
            var b2 = new Point(b, 0, b);
            var b3 = new Point(b, 0, -b);

            // base
            _wireframe.Connect(b0, b1);
            _wireframe.Connect(b1, b2);
            _wireframe.Connect(b2, b3);
            _wireframe.Connect(b3, b0);

            // columns
            _wireframe.SquareColumn(new DynamicPoint(() => new Vector3(-_data.ColumnSpacing, 0, -_data.ColumnSpacing)), () => _data.Height, () => _data.ColumnSize);
            _wireframe.SquareColumn(new DynamicPoint(() => new Vector3(-_data.ColumnSpacing, 0, _data.ColumnSpacing)), () => _data.Height, () => _data.ColumnSize);
            _wireframe.SquareColumn(new DynamicPoint(() => new Vector3(_data.ColumnSpacing, 0, _data.ColumnSpacing)), () => _data.Height, () => _data.ColumnSize);
            _wireframe.SquareColumn(new DynamicPoint(() => new Vector3(_data.ColumnSpacing, 0, -_data.ColumnSpacing)), () => _data.Height, () => _data.ColumnSize);

            // roof
            _wireframe.SquareColumn(new DynamicPoint(() => new Vector3(0, _data.Height, 0)), () => _data.RoofThickness, () => .5f);
            _wireframe.SquareColumn(new DynamicPoint(() => new Vector3(0, _data.Height + _data.RoofThickness, 0)), () => _data.RoofThickness, () => .4f);
        }
    }
}
