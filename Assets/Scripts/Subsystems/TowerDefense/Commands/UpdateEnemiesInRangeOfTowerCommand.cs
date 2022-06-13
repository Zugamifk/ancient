using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TowerDefense.Models;

namespace TowerDefense.Commands
{
    public class UpdateEnemiesInRangeOfTowerCommand : ICommand
    {
        Guid _id;
        public UpdateEnemiesInRangeOfTowerCommand(Guid id)
        {
            _id = id;
        }

        public void Execute(GameModel model)
        {
            var towerDefenseModel = model.GetModel<TowerDefenseGameModel>();
            var tower = towerDefenseModel.Towers.GetItem(_id);
            tower.EnemiesInRange.Clear();
            foreach (var e in towerDefenseModel.EnemyIds.Select(model.Characters.GetItem))
            {
                if (Vector2.Distance(e.Position, tower.Position) < tower.AttackRadius)
                {
                    tower.EnemiesInRange.Add(e.Id);
                }
            }
        }
    }
}