using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
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
            var tower = model.TurretDefenseModel.Turrets.GetItem(_id);
            tower.EnemiesInRange.Clear();
            foreach (var e in model.TurretDefenseModel.Enemies)
            {
                if (Vector2.Distance(e.Position, tower.Position) < tower.AttackRadius)
                {
                    tower.EnemiesInRange.Add(e.Id);
                }
            }
        }
    }
}