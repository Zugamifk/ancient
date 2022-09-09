using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TowerDefense.Models;
using Model;

namespace TowerDefense.Commands
{
    public class UpdateProjectilesCommand : ICommand
    {
        public void Execute(GameModel model)
        {
            var towerDefenseModel = model.GetModel<TowerDefenseGameModel>();
            List<Projectile> toRemove = new List<Models.Projectile>();
            foreach(var p in towerDefenseModel.Projectiles.AllItems)
            {
                p.Trajectory.Step(p.MoveSpeed * Time.deltaTime);
                if (p.Trajectory.AtEnd)
                {
                    Game.Do(new DamageAreaCommand(p.Position, 2));
                    toRemove.Add(p);
                }
            }
            foreach(var p in toRemove)
            {
                towerDefenseModel.Projectiles.RemoveItem(p.Id);
                model.AllIdentifiables.RemoveItem(p.Id);
            }
        }
    }
}
