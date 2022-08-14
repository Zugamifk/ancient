using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MeshGenerator
{
    public class CreateHalfEdgeStep : ISubStep
    {
        int _index;
        HalfEdge _halfEdge;
        public CreateHalfEdgeStep(int index)
        {
            _index = index;
        }

        public void Do(SurfaceModelBuilder builder)
        {
            _halfEdge = builder.CreateHalfEdge(_index);
        }

        public void Undo(SurfaceModelBuilder builder)
        {
            builder.RemoveHalfEdge(_halfEdge);
        }
    }
}
