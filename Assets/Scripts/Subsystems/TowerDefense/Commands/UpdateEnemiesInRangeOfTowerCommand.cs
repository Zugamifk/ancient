using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

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
            var tower = model.TowerDefense.Towers.GetItem(_id);
            tower.EnemiesInRange.Clear();
            foreach (var e in model.TowerDefense.EnemyIds.Select(model.Characters.GetItem))
            {
                if (Vector2.Distance(e.Position, tower.Position) < tower.AttackRadius)
                {
                    tower.EnemiesInRange.Add(e.Id);
                }
            }
        }
    }
}