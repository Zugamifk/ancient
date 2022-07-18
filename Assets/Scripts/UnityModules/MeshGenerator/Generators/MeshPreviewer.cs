using UnityEngine;

namespace MeshGenerator
{
    public class MeshPreviewer : MonoBehaviour
    {
        [CallMethodButton("Generate", "Generate Mesh")]
        [SerializeField]
        Mesh _mesh;
        [SerializeField]
        EMeshType _meshType;
        [SerializeField]
        Transform _generatorTransform;

        public IMeshGenerator CurrentGenerator { get; private set; }

        public void SetMesh(Mesh mesh)
        {
            var mf = GetComponent<MeshFilter>();
            mf.mesh = mesh;
            _mesh = mesh;
        }
    }
}
