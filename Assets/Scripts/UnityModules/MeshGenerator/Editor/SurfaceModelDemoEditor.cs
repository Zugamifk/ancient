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
                var v2 = v1.HalfEdge.Twin.Vertex;

                Handles.DrawLine(v1.Position, v2.Position);
            }

            Handles.color = Color.yellow;
            foreach (var h in model.HalfEdges)
            {
                var v1 = h.Vertex.Position;
                var v2 = h.Twin.Vertex.Position;
                var dir = (v2 - v1).normalized;
                var n = Vector3.Cross(dir, fwd);

                var p1 = v1 + dir * smd.HalfEdgeShorten + n * smd.HalfEdgeDistance;
                var p2 = v2 - dir * smd.HalfEdgeShorten + n * smd.HalfEdgeDistance;
                Handles.DrawSolidDisc(p1, fwd, .01f);
                Handles.DrawLine(p1, p2);

                Handles.DrawWireArc(v2, fwd, Vector3.up, 90, smd.HalfEdgeShorten);
            }
        }
    }
}
