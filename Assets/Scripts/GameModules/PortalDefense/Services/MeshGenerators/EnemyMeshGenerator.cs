using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MeshGenerator;
using MeshGenerator.Wireframe;
using PortalDefense.Data;

namespace PortalDefense.Services
{
    [MeshGenerator("Enemy")]
    public class EnemyMeshGenerator : IGeometryGenerator
    {
        static EnemyMeshGeneratorData _data;
        public EnemyMeshGeneratorData Data
        {
            get
            {
                if (_data == null)
                {
                    _data = DataService.GetData<PortalDefenseMeshGeneratorDataCollection>().Enemy;
                }
                return _data;
            }
        }

        public Frame Wireframe => _wireframe;

        Frame _wireframe;

        public void Generate(MeshBuilder builder)
        {
            var f = Data.Fatness;
            var p0 = new Vector3(-f, 0, -f);
            var p1 = new Vector3(-f, 0, f);
            var p2 = new Vector3(f, 0, f);
            var p3 = new Vector3(f, 0, -f);
            var h = Data.Height;
            var p4 = p0 + new Vector3(0, h, 0);
            var p5 = p1 + new Vector3(0, h, 0);
            var p6 = p2 + new Vector3(0, h, 0);
            var p7 = p3 + new Vector3(0, h, 0);

            builder.SetColor(Data.BodyColor);
            builder.AddQuad(p3, p2, p1, p0);
            builder.AddQuad(p0, p1, p5, p4);
            builder.AddQuad(p1, p2, p6, p5);
            builder.AddQuad(p2, p3, p7, p6);
            builder.AddQuad(p3, p0, p4, p7);
            builder.AddQuad(p4, p5, p6, p7);
        }

        public void BuildWireframe()
        {
            _wireframe = new();

            _wireframe.SquareColumn(new Point(), () => Data.Height, () => Data.Fatness);
        }
    }
}
