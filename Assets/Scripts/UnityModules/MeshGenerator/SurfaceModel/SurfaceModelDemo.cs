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
            builder.AddPoint(Vector3.zero);
            builder.AddPoint(Vector3.up);
            builder.AddPoint(new Vector3(1, 1, 0));
            builder.AddPoint(Vector3.right);
            var e1 = builder.ConnectPoints(0, 1);
            builder.ConnectPoints(1, 2);
            builder.ConnectPoints(3, 2);
            builder.ConnectPoints(0, 3);
            builder.CreateFace(e1.HalfEdge);
            builder.AddPoint(new Vector3(0, 1, 1));
            builder.AddPoint(new Vector3(1, 1, 1));
            var e2 = builder.ConnectPoints(1, 4);
            builder.ConnectPoints(4, 5);
            builder.ConnectPoints(5, 2);
            builder.CreateFace(e2.HalfEdge);
        }
    }
}
