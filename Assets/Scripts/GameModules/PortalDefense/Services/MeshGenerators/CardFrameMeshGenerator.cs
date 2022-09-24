using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MeshGenerator;
using MeshGenerator.Wireframe;
using PortalDefense.Data;

namespace PortalDefense.Services
{
    [MeshGenerator("Card Frame")]
    public class CardFrameMeshGenerator : MeshGeneratorWithWireFrame<CardFrameMeshGeneratorData>
    {
        public override void BuildWireframe()
        {
            Wireframe = new();

            var w = Data.BaseDimensions.x / 2;
            var h = Data.BaseDimensions.y / 2;
            var p0 = new Point(-w, -h, 0);
            var p1 = new Point(-w, h, 0);
            var p2 = new Point(w, h, 0);
            var p3 = new Point(w, -h, 0);

            Wireframe.ConnectLoop(p0, p1, p2, p3);
        }

        public override void Generate(MeshBuilder builder)
        {
        }

        protected override CardFrameMeshGeneratorData LoadData() => DataService.GetData<PortalDefenseMeshGeneratorDataCollection>().CardFrame;
    }
}
