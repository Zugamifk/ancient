using MeshGenerator;
using PortalDefense.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PortalDefense.View
{
    public class PortalDefenseEnemy : MonoBehaviour
    {
        [SerializeField]
        MeshFilter _meshFilter;
        [SerializeField]
        Transform _viewRoot;

        private void Start()
        {
            var gen = new EnemyMeshGenerator();
            var builder = new MeshBuilder();
            gen.Generate(builder);
            var mesh = builder.BuildMesh();
            _meshFilter.mesh = mesh;
        }

        public void SetEnemy(Guid id)
        {

        }
    }
}
