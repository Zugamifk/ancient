using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MeshGenerator
{
    [ExecuteInEditMode]
    public class SurfaceModelDemo : MonoBehaviour
    {
        SurfaceModel _model;

        void OnEnable()
        {
            _model = new();
            var builder = new SurfaceModelBuilder(_model);
            builder = builder.AddPoint(Vector3.zero)
                .AddPoint(Vector3.up);
            _model = builder.Build();
            Debug.Log("Generated");
        }

        private void OnDrawGizmos()
        {
            if (_model == null) return;

            Gizmos.matrix = transform.localToWorldMatrix;

            foreach(var v in _model.Vertices)
            {
                Gizmos.DrawSphere(v.Position, .1f);
            }
        }
    }
}
