using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PortalDefense.ViewModel;

namespace PortalDefense.View
{
    public class PortalDefenseEnemySpawn : MonoBehaviour
    {
        Guid _id;

        public void Initialize(Guid id)
        {
            _id = id;
        }

        private void Update()
        {
            var pdm = Game.Model.GetModel<IPortalDefenseModel>();
            foreach(var e in pdm.Spawns.GetItem(_id).SpawnQueue)
            {
                var enemy = pdm.SpawnedEnemies.GetItem(e);
                SpawnEnemy(enemy);
            }
        }

        void SpawnEnemy(IEnemyModel enemy)
        {

        }
    }
}
