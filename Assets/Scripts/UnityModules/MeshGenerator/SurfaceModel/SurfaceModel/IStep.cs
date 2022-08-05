using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MeshGenerator
{
    public interface IStep
    {
        void Do(SurfaceModelBuilder builder);
        void Undo(SurfaceModelBuilder builder);
    }
}
