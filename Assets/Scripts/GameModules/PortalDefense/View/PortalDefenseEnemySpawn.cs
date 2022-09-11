using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PortalDefense.ViewModel;
using PortalDefense.Data;

namespace PortalDefense.View
{
    public class PortalDefenseEnemySpawn : MonoBehaviour
    {
        [SerializeField] Transform _spawnPosition;

        Identifiable _identifiable;

        private void Awake()
        {
            _identifiable = GetComponent<Identifiable>();
        }

        private void Update()
        {
            var pdm = Game.Model.GetModel<IPortalDefenseModel>();
            foreach(var e in pdm.Spawns.GetItem(_identifiable.Id).SpawnQueue)
            {
                var enemy = pdm.SpawnedEnemies.GetItem(e);
                SpawnEnemy(enemy);
            }
        }

        void SpawnEnemy(IEnemyModel enemy)
        {
            var enemyPrefab = Prefabs.GetInstance(enemy);
            enemyPrefab.transform.SetParent(PortalDefenseGame.Instance.SpawnRoot);
            enemyPrefab.transform.position = _spawnPosition.position;

            var identifiable = enemyPrefab.GetComponent<Identifiable>();
            identifiable.Id = enemy.Id;
        }
    }
}
