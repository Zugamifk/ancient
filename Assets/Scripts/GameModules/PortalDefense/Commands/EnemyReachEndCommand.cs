using Model;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PortalDefense.Model;

namespace PortalDefense.Commands
{
    public class EnemyReachEndCommand : ICommand
    {
        Guid _id;
        public EnemyReachEndCommand(Guid id) => _id = id;

        public void Execute(GameModel model)
        {
            var pdm = model.GetModel<PortalDefenseModel>();
            pdm.SpawnedEnemies.RemoveItem(_id);
        }
    }
}
