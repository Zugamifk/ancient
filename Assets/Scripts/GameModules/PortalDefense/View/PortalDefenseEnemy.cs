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
    public class PortalDefenseEnemy : PortalDefenseMeshGeneratorUser
    {
        [SerializeField]
        MeshFilter _meshFilter;

        Identifiable _identifiable;

        public Guid Id => _identifiable.Id;

        private void Awake()
        {
            _identifiable = GetComponent<Identifiable>();
        }

        private void Start()
        {
            AssignMesh<EnemyMeshGenerator>(_meshFilter);   
        }

        private void Update()
        {
            var enemy = Game.Model.GetModel<IPortalDefenseModel>().SpawnedEnemies.GetItem(_identifiable.Id);
            if(enemy == null)
            {
                Destroy(gameObject);
                return;
            }

            var position = enemy.Position;
            position.y = PortalDefenseGame.Instance.Map.GetTile(new Vector2Int((int)(position.x+.5f), (int)(position.z+.5f))).SurfaceY;
            transform.position = position;
            Game.Do(new UpdateEnemyMovementCommand(_identifiable.Id));
        }
    }
}
