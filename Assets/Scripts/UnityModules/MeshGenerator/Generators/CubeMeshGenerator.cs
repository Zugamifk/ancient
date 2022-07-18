using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MeshGenerator
{
    public class CubeMeshGenerator : IMeshGenerator
    {
        public Mesh Generate(MeshGeneratorContext context)
        {
            var m = new Mesh();
            m.name = "Cube";

            var v = new Vector3[]
            {
                new Vector3(-.5f,.5f,-.5f), new Vector3(-.5f,.5f,.5f), new Vector3(.5f,.5f,.5f), new Vector3(.5f,.5f,-.5f),
                new Vector3(-.5f,-.5f,-.5f), new Vector3(-.5f,-.5f,.5f), new Vector3(-.5f,.5f,.5f), new Vector3(-.5f,.5f,-.5f),
                new Vector3(.5f,-.5f,.5f), new Vector3(.5f,.5f,.5f), new Vector3(-.5f,.5f,.5f), new Vector3(-.5f,-.5f,.5f),
                new Vector3(.5f,-.5f,-.5f), new Vector3(.5f,.5f,-.5f), new Vector3(.5f,.5f,.5f), new Vector3(.5f,-.5f,.5f),
                new Vector3(-.5f,-.5f,-.5f), new Vector3(-.5f,.5f,-.5f), new Vector3(.5f,.5f,-.5f), new Vector3(.5f,-.5f,-.5f),
                new Vector3(-.5f,-.5f,-.5f), new Vector3(.5f,-.5f,-.5f), new Vector3(.5f,-.5f,.5f), new Vector3(-.5f,-.5f,.5f),
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

            for (int i = 0; i < 24; i++)
            {
                v[i] = context.Transform.MultiplyPoint3x4(v[i]);
                n[i] = context.Transform.MultiplyVector(n[i]);
            }

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
