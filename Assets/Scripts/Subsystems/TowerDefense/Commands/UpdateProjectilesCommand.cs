using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense.Commands
{
    public class UpdateProjectilesCommand : ICommand
    {
        public void Execute(GameModel model)
        {
            List<Models.Projectile> toRemove = new List<Models.Projectile>();
            foreach(var p in model.TowerDefense.Projectiles.AllItems)
            {
                p.Trajectory.Step(Time.deltaTime);
                if (p.Trajectory.AtEnd)
                {
                    Game.Do(new DamageAreaCommand(p.Position, 2));
                    toRemove.Add(p);
                }
            }
            foreach(var p in toRemove)
            {
                model.TowerDefense.Projectiles.RemoveItem(p.Id);
            }
        }
    }
}
