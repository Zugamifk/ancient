using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace MeshGenerator
{
    [ExecuteInEditMode]
    public class SurfaceModelDemo : MonoBehaviour
    {
        public float HalfEdgeDistance = .1f;
        public float HalfEdgeShorten = .1f;
        public float FaceInset = .25f;
        public bool ShowEdgeLabels;
        public bool ShowHalfEdgeLabels;

        public SurfaceModel Model;

        void OnEnable()
        {
            Model = new();
            var builder = new SurfaceModelBuilder(Model);
            var v0 = builder.AddPoint(Vector3.zero);
            var v1 = builder.AddPoint(Vector3.up);
            var v2 = builder.AddPoint(new Vector3(1, 1, 0));
            var v3 = builder.AddPoint(Vector3.right);
            var e1 = builder.ConnectPoints(v0, v1);
            builder.ConnectPoints(v1, v2);
            builder.ConnectPoints(v3, v2);
            builder.ConnectPoints(v0, v3);
            builder.CreateFace(v0, v1, v2, v3);
            var v4 = builder.AddPoint(new Vector3(0, 2, 0));
            var v5 = builder.AddPoint(new Vector3(1, 2, 0));
            var e2 = builder.ConnectPoints(v1, v4);
            builder.ConnectPoints(v4, v5);
            builder.ConnectPoints(v5, v2);
            builder.CreateFace(v1, v4, v5, v2);
            var v6 = builder.AddPoint(new Vector3(2, 0, 0));
            var v7 = builder.AddPoint(new Vector3(2, 1, 0));
            var v8 = builder.AddPoint(new Vector3(2, 2, 0));
            builder.ConnectPoints(v3, v6);
            builder.ConnectPoints(v2, v7);
            builder.ConnectPoints(v5, v8);
            builder.ConnectPoints(v6, v7);
            builder.ConnectPoints(v7, v8);
        }
    }
}
