using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MeshGenerator
{
    public class PrimitiveMeshGenerator : MonoBehaviour
    {
        [CallMethodButton("Generate", "Generate Mesh")]
        
        [SerializeField]
        EPrimitiveMeshType _meshType;

        public Mesh Generate()
        {
            return default;
        }
    }
}
