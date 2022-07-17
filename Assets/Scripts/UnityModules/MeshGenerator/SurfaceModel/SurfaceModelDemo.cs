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
        public SurfaceModel Model;

        void OnEnable()
        {
            Model = new();
            var builder = new SurfaceModelBuilder(Model);
            builder.AddPoint(Vector3.zero);
            builder.AddPoint(Vector3.up);
            builder.ConnectPoints(0, 1);
            Debug.Log("Generated");
        }
    }
}
