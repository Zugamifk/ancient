using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense.Commands
{
    public class UpdateProjectilesCommand : ICommand
    {
        public void Execute(GameModel model)
        {
            foreach(var p in model.TowerDefense.Projectiles.AllItems)
            {
                p.Trajectory.Step(Time.deltaTime);
            }
        }
    }
}
