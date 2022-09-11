using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PortalDefense.Services;
using MeshGenerator;
using PortalDefense.Commands;

namespace PortalDefense.View
{
    public class PortalDefenseEndPortal : MonoBehaviour
    {
        [SerializeField]
        MeshFilter _meshFilter;

        private void Start()
        {
            var gen = new EndPortalMeshGenerator();
            var builder = new MeshBuilder();
            gen.Generate(builder);
            var mesh = builder.BuildMesh();
            _meshFilter.mesh = mesh;
        }

        private void OnTriggerEnter(Collider other)
        {
            var enemy = other.gameObject.GetComponent<PortalDefenseEnemy>();
            if (enemy!=null)
            {
                Game.Do(new EnemyReachEndCommand(enemy.Id));
            }
        }
    }
}
