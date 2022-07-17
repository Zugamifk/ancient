using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace MeshGenerator
{
    [ExecuteInEditMode]
    public class SurfaceModelDemo : MonoBehaviour
    {
        [SerializeField]
        float _halfEdgeDistance = .1f;
        [SerializeField]
        float _halfEdgeShorten = .1f;
        SurfaceModel _model;

        void OnEnable()
        {
            _model = new();
            var builder = new SurfaceModelBuilder(_model);
            builder = builder
                .AddPoint(Vector3.zero)
                .AddPoint(Vector3.up)
                .ConnectPoints(0, 1);
            _model = builder.Build();
            Debug.Log("Generated");
        }

        private void OnDrawGizmos()
        {
            if (_model == null) return;

            Gizmos.matrix = transform.localToWorldMatrix;

            Gizmos.color = Color.blue;
            foreach(var v in _model.Vertices)
            {
                Gizmos.DrawSphere(v.Position, .1f);
            }

            Gizmos.color = Color.green;
            foreach(var e in _model.Edges)
            {
                var v1 = e.HalfEdge.Vertex;
                var v2 = v1.HalfEdge.Twin.Vertex;

                Gizmos.DrawLine(v1.Position, v2.Position);
            }

            Gizmos.color = Color.yellow;
            var fwd = SceneView.currentDrawingSceneView.camera.transform.forward;
            foreach(var h in _model.HalfEdges)
            {
                var v1 = h.Vertex.Position;
                var v2 = h.Twin.Vertex.Position;
                var dir = (v2 - v1).normalized;
                var n = Vector3.Cross(dir, fwd);

                var p1 = v1 + dir * _halfEdgeShorten + n * _halfEdgeDistance;
                var p2 = v2 - dir * _halfEdgeShorten + n * _halfEdgeDistance;
                Gizmos.DrawSphere(p1, .01f);
                Gizmos.DrawLine(p1, p2);
            }
        }
    }
}
