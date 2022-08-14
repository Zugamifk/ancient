using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MeshGenerator
{
    public class ConnectVerticesStep : IStep
    {
        int _i0, _i1;
        Edge _edge;

        public ConnectVerticesStep(int i0, int i1) {
            _i0 = i0;
            _i1 = i1;
        }

        public void Do(SurfaceModelBuilder builder)
        {
            _edge = builder.CreateEdge(_i0, _i1);
        }

        public void Undo(SurfaceModelBuilder builder)
        {
            builder.RemoveEdge(_edge);
        }
    }
}
