using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MeshGenerator
{
    public class SurfaceModelMeshGenerator : IGeometryGenerator
    {
        SurfaceModel _model;

        public SurfaceModel Model => Model;

        public SurfaceModelMeshGenerator(SurfaceModel model)
        {
            var cb = new CubeGenerator();
            var b = new MeshBuilder();
            cb.Generate(b, Matrix4x4.identity);
            var m = b.Build(new());
            var smb = new MeshToSurfaceModelBuilder();
            _model = smb.ConvertMesh(m);
        }

        public void Generate(MeshBuilder builder, Matrix4x4 matrix)
        {
            foreach(var f in _model.Faces)
            {
                builder.AddPolygon(f.HalfEdge.Loop().Select(he => he.Vertex.Position).ToArray());
            }
        }
    }
}
