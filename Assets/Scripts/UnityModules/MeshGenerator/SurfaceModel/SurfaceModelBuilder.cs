using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MeshGenerator
{
    public class SurfaceModelBuilder
    {
        SurfaceModel _model;

        public SurfaceModelBuilder(SurfaceModel model) => _model = model;

        public SurfaceModelBuilder AddPoint(Vector3 point)
        {
            var v = new Vertex();
            v.Position = point;
            _model.Vertices.Add(v);
            return this;
        }

        public SurfaceModel Build() => _model;
    }
}
