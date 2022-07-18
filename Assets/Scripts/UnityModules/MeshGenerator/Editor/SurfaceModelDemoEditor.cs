using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace MeshGenerator.Editor
{
    [CustomEditor(typeof(SurfaceModelDemo))]
    public class SurfaceModelDemoEditor : UnityEditor.Editor
    {
        void OnSceneGUI()
        {
            var smd = (SurfaceModelDemo)target;
            var model = smd.Model;

            if (model == null) return;

            Handles.matrix = smd.transform.localToWorldMatrix;

            var fwd = SceneView.currentDrawingSceneView.camera.transform.forward;

            Handles.color = Color.blue;
            foreach (var v in model.Vertices)
            {
                Handles.DrawSolidDisc(v.Position, fwd, .1f);
            }

            Handles.color = Color.green;
            foreach (var e in model.Edges)
            {
                var v1 = e.HalfEdge.Vertex;
                var v2 = e.HalfEdge.Twin.Vertex;
                if (smd.ShowEdgeLabels)
                {
                    Handles.Label(Vector3.Lerp(v1.Position, v2.Position, .5f), e.ToString());
                }
                Handles.DrawLine(v1.Position, v2.Position);
            }

            foreach (var h in model.HalfEdges)
            {
                var v1 = h.Vertex.Position;
                var v2 = h.Twin.Vertex.Position;
                var dir = (v2 - v1).normalized;
                var n = Vector3.Cross(dir, fwd);

                var p1 = v1 + dir * smd.HalfEdgeShorten + n * smd.HalfEdgeDistance;
                var p2 = v2 - dir * smd.HalfEdgeShorten + n * smd.HalfEdgeDistance;

                Handles.color = Color.yellow;
                HandleX.DrawArrow(p1, p2, fwd, .02f);

                if (smd.ShowHalfEdgeLabels)
                {
                    Handles.Label(Vector3.Lerp(p1, p2, .25f), h.ToString());
                }

                var v3 = h.Next.To.Position;
                var dir2 = (v3 - v2).normalized;
                var n2 = Vector3.Cross(dir2, fwd);
                var p3 = v2 + dir2 * smd.HalfEdgeShorten + n2 * smd.HalfEdgeDistance;

                Handles.color = Color.red;
                HandleX.DrawArrow(p2, p3, fwd, .02f);

                if (h.Face != Face.Outside)
                {
                    Handles.color = Color.magenta;
                    var p4 = Vector3.Lerp(p1, p2, .5f);
                    HandleX.DrawArrow(p4, h.Face.Centre(), fwd, 0.02f);
                }
            }
        }
    }
}
