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
        }

        public void BuildWireframe()
        {
            _wireframe = new();

            var b = .5f;
            var b0 = new Point(-b, 0, -b);
            var b1 = new Point(-b, 0, b);
            var b2 = new Point(b, 0, b);
            var b3 = new Point(b, 0, -b);

            _wireframe.Connect(b0, b1);
            _wireframe.Connect(b1, b2);
            _wireframe.Connect(b2, b3);
            _wireframe.Connect(b3, b0);
        }
    }
}
