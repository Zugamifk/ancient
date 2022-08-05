using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MeshGenerator.Editor
{
    public interface IStep
    {
        void Do(SurfaceModelBuilder builder);
        void Undo(SurfaceModelBuilder builder);
    }
}
