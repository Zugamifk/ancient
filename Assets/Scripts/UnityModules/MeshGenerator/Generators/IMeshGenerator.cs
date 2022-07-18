using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MeshGenerator
{
    public interface IMeshGenerator
    {
        Mesh Generate(MeshGeneratorContext context);
    }
}
