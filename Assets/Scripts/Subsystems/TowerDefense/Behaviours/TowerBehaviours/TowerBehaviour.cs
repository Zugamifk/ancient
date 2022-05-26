using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TowerDefense.Models;

namespace TowerDefense.Behaviours
{
    public class TowerBehaviour
    {
        FiringBehaviour _firing = new();

        public void UpdateFiringState(GameModel game, Tower tower)
        {
            var cooldown = 1 / tower.ShotsPerSecond;
            tower.ShotCooldown -= game.TimeModel.LastDeltaTime;
            while(tower.ShotCooldown < 0)
            {
                tower.ShotCooldown += cooldown;

                var projectile = new Projectile()
                {

                };
                game.TowerDefense.Projectiles.AddItem(projectile);
            }
        }
    }
}
