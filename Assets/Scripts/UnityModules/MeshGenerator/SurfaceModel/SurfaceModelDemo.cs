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
        public bool ShowEdgeLabels;
        public bool ShowHalfEdgeLabels;

        public SurfaceModel Model;

        void OnEnable()
        {
            Model = new();
            var builder = new SurfaceModelBuilder(Model);
            builder.AddPoint(Vector3.zero);
            builder.AddPoint(Vector3.up);
            builder.AddPoint(new Vector3(1,1,0));
            builder.AddPoint(Vector3.right);
            builder.ConnectPoints(0, 1);
            builder.ConnectPoints(1, 2);
            builder.ConnectPoints(3, 2);
            builder.ConnectPoints(0, 3);
            Debug.Log("Generated");
        }
    }
}
