using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PortalDefense.ViewModel;
using MeshGenerator;

namespace PortalDefense.Services
{
    public class MapMeshGenerator
    {
        MeshBuilder _builder = new();
        public Mesh GenerateTileMesh(ITileModel tile)
        {
            _builder.SetColor(new Color(.25f, .75f, .25f, 1));

            var h = tile.Height;
            var p0 = new Vector3(-.5f, 0, -.5f);
            var p1 = new Vector3(-.5f, 0, .5f);
            var p2 = new Vector3(.5f, 0, .5f);
            var p3 = new Vector3(.5f, 0, -.5f);
            var p4 = new Vector3(-.5f, h, -.5f);
            var p5 = new Vector3(-.5f, h, .5f);
            var p6 = new Vector3(.5f, h, .5f);
            var p7 = new Vector3(.5f, h, -.5f);

            _builder.AddQuad(p0, p3, p2, p1);
            _builder.AddQuad(p0, p4, p7, p3);
            _builder.AddQuad(p0, p1, p5, p4);
            _builder.AddQuad(p1, p2, p6, p5);
            _builder.AddQuad(p3, p7, p6, p2);
            _builder.AddQuad(p4, p5, p6, p7);

            return _builder.Build();
        }
    }
}
