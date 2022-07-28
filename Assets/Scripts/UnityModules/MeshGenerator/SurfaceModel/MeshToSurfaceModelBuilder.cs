using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MeshGenerator
{
    public class MeshToSurfaceModelBuilder
    {
        public SurfaceModel ConvertMesh(Mesh mesh)
        {
            var model = new SurfaceModel();
            var builder = new SurfaceModelBuilder(model);

            List<Vector3> points = new();
            var tris = mesh.triangles;
            var verts = mesh.vertices;
            int[] reindexed = new int[verts.Length];
            for (int i = 0; i < verts.Length; i++)
            {
                reindexed[i] = i;
                for (int j = 0; j < points.Count; j++)
                {
                    if (points[j] == verts[i])
                    {
                        reindexed[i] = j;
                    }
                }
                if (reindexed[i] == i)
                {
                    reindexed[i] = points.Count;
                    points.Add(verts[i]);
                }
            }

            foreach (var v in points)
            {
                builder.AddPoint(v);
            }

            for (int i = 0; i < tris.Length; i += 3)
            {
                var p0 = reindexed[tris[i]];
                var p1 = reindexed[tris[i + 1]];
                var p2 = reindexed[tris[i + 2]];
                builder.CreateFace(p0, p1, p2);
            }

            return model;
        }
    }
}
