using MeshGenerator;
using PortalDefense.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PortalDefense.Commands;
using PortalDefense.ViewModel;

namespace PortalDefense.View
{
    public class PortalDefenseEnemy : MonoBehaviour
    {
        [SerializeField]
        MeshFilter _meshFilter;

        Identifiable _identifiable;

        private void Awake()
        {
            _identifiable = GetComponent<Identifiable>();
        }

        private void Start()
        {
            var gen = new EnemyMeshGenerator();
            var builder = new MeshBuilder();
            gen.Generate(builder);
            var mesh = builder.BuildMesh();
            _meshFilter.mesh = mesh;
        }

        private void Update()
        {
            var enemy = Game.Model.GetModel<IPortalDefenseModel>().SpawnedEnemies.GetItem(_identifiable.Id);
            var position = enemy.Position;
            position.y = PortalDefenseGame.Instance.Map.GetTile(new Vector2Int((int)position.x, (int)position.z)).SurfaceY;
            transform.position = position;
            Game.Do(new UpdateEnemyMovementCommand(_identifiable.Id));
        }
    }
}
