using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MeshGenerator;
using MeshGenerator.Wireframe;
using PortalDefense.Data;
using System;

namespace PortalDefense.Services
{
    [MeshGenerator("Card Frame")]
    public class CardFrameMeshGenerator : MeshGeneratorWithWireFrame<CardFrameMeshGeneratorData>
    {
        public override void BuildWireframe()
        {
            Wireframe = new();

            Func<float> w = () => Data.BaseDimensions.x / 2;
            Func<float> h = () => Data.BaseDimensions.y / 2;
            var p0 = new DynamicPoint(() => new Vector3(-w(), -h(), 0));
            var p1 = new DynamicPoint(() => new Vector3(-w(), h(), 0));
            var p2 = new DynamicPoint(() => new Vector3(w(), h(), 0));
            var p3 = new DynamicPoint(() => new Vector3(w(), -h(), 0));

            Wireframe.ConnectLoop(p0, p1, p2, p3);

            Func<float> bw = () => w() + Data.BorderWidth;
            Func<float> bh = () => h() + Data.BorderWidth;
            var b0 = new DynamicPoint(() => new Vector3(-bw(), -bh(), 0));
            var b1 = new DynamicPoint(() => new Vector3(-bw(), bh(), 0));
            var b2 = new DynamicPoint(() => new Vector3(bw(), bh(), 0));
            var b3 = new DynamicPoint(() => new Vector3(bw(), -bh(), 0));
            Wireframe.ConnectLoop(b0, b1, b2, b3);

            Func<float> dw = () => Data.DividerWidth / 2;
            Func<float> d = () => Mathf.Lerp(dw(), Data.BaseDimensions.y - dw(), Data.DividerPosition);
            var d0 = new DynamicPoint(() => p0.Position + new Vector3(0, d() - dw(), 0));
            var d1 = new DynamicPoint(() => p3.Position + new Vector3(0, d() - dw(), 0));
            Wireframe.Connect(d0, d1);
            var d2 = new DynamicPoint(() => p0.Position + new Vector3(0, d() + dw(), 0));
            var d3 = new DynamicPoint(() => p3.Position + new Vector3(0, d() + dw(), 0));
            Wireframe.Connect(d2, d3);
        }

        public override void Generate(MeshBuilder builder)
        {
            builder.SetColor(Color.white);

            var w = Data.BaseDimensions.x / 2;
            var h = Data.BaseDimensions.y / 2;
            var p0 = new Vector3(-w, -h, 0);
            var p1 = new Vector3(-w, h, 0);
            var p2 = new Vector3(w, h, 0);
            var p3 = new Vector3(w, -h, 0);
            builder.AddQuad(p0, p1, p2, p3);

            var bw = w + Data.BorderWidth;
            var bh = h + Data.BorderWidth;
            var b0 = new Vector3(-bw, -bh, 0);
            var b1 = new Vector3(-bw, bh, 0);
            var b2 = new Vector3(bw, bh, 0);
            var b3 = new Vector3(bw, -bh, 0);

            var f = new Vector3(0, 0, .5f);
            builder.AddCubic(p0 + f, b0 + f, b1 + f, p1 + f, p0, b0, b1, p1);
        }

        protected override CardFrameMeshGeneratorData LoadData() => DataService.GetData<PortalDefenseMeshGeneratorDataCollection>().CardFrame;
    }
}
