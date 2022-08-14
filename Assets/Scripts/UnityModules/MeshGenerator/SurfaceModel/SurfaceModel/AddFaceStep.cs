using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MeshGenerator
{
    public class AddFaceStep : IStep
    {
        int[] _vertices;

        public AddFaceStep(params int[] indices)
        {
            _vertices = indices;
        }

        public void Do(SurfaceModelBuilder builder)
        {
            builder.CreateFace(_vertices);
        }

        public void Undo(SurfaceModelBuilder builder)
        {
            throw new System.NotImplementedException();
        }
    }
}
