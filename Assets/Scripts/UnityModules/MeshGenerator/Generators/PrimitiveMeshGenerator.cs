using UnityEngine;

namespace MeshGenerator
{
    public class PrimitiveMeshGenerator : MonoBehaviour
    {
        [CallMethodButton("Generate", "Generate Mesh")]
        [SerializeField]
        Mesh _mesh;
        [SerializeField]
        EPrimitiveMeshType _meshType;
        [SerializeField]
        Transform _generatorTransform;

        public Mesh Generate()
        {
            Mesh m = default;
            IMeshGenerator generator = default;
            switch (_meshType)
            {
                case EPrimitiveMeshType.Cube:
                    generator = new CubeMeshGenerator();
                    break;
                default:
                    break;
            }

            var mf = GetComponent<MeshFilter>();
            var context = new MeshGeneratorContext() {
                Position = _generatorTransform.localPosition,
                Rotation = _generatorTransform.localRotation,
                Scale = _generatorTransform.localScale
            };
            mf.mesh = generator.Generate(context);
            return m;
        }
    }
}
