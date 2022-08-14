using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MeshGenerator
{
    public class CreateHalfEdgeStep : ISubStep
    {
        int _index;
        public CreateHalfEdgeStep(int index)
        {
            _index = index;
        }

        public void Do(SurfaceModelBuilder builder)
        {
            builder.CreateHalfEdge(_index);
        }

        public void Undo(SurfaceModelBuilder builder)
        {
            throw new System.NotImplementedException();
        }
    }
}
