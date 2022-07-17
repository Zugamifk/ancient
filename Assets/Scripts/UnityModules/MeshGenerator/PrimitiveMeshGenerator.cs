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
        float _size = 1;

        public Mesh Generate()
        {
            Mesh m = default;
            switch (_meshType)
            {
                case EPrimitiveMeshType.Cube:
                    m = GenerateCube();
                    break;
                default:
                    break;
            }

            var mf = GetComponent<MeshFilter>();
            mf.mesh = m;
            return m;
        }

        Mesh GenerateCube()
        {
            var m = new Mesh();
            m.name = "Cube";

            var r = _size / 2;
            var v = new Vector3[]
            {
                new Vector3(-r,r,-r), new Vector3(-r,r,r), new Vector3(r,r,r), new Vector3(r,r,-r),
                new Vector3(-r,-r,-r), new Vector3(-r,-r,r), new Vector3(-r,r,r), new Vector3(-r,r,-r),
                new Vector3(r,-r,r), new Vector3(r,r,r), new Vector3(-r,r,r), new Vector3(-r,-r,r),
                new Vector3(r,-r,-r), new Vector3(r,r,-r), new Vector3(r,r,r), new Vector3(r,-r,r),
                new Vector3(-r,-r,-r), new Vector3(-r,r,-r), new Vector3(r,r,-r), new Vector3(r,-r,-r),
                new Vector3(-r,-r,-r), new Vector3(r,-r,-r), new Vector3(r,-r,r), new Vector3(-r,-r,r),
            };
            var n = new Vector3[]
            {
                Vector3.up, Vector3.up, Vector3.up, Vector3.up,
                Vector3.left,Vector3.left,Vector3.left,Vector3.left,
                Vector3.forward,Vector3.forward,Vector3.forward,Vector3.forward,
                Vector3.right,Vector3.right,Vector3.right,Vector3.right,
                Vector3.back,Vector3.back,Vector3.back,Vector3.back,
                Vector3.down,Vector3.down,Vector3.down,Vector3.down,
            };
            var t = new int[]
            {
                0, 1, 2, 0, 2, 3,
                4, 5, 6, 4, 6, 7,
                8, 9, 10, 8, 10, 11,
                12, 13, 14, 12, 14, 15,
                16, 17, 18, 16, 18, 19,
                20, 21, 22, 20, 22, 23
            };
            m.vertices = v;
            m.normals = n;
            m.triangles = t;
            return m;
        }
    }
}
