using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TowerDefense.Models;
using System.Linq;

namespace TowerDefense.Behaviours
{
    public class TowerBehaviour
    {
        public void FireProjectiles(GameModel game, Tower tower)
        {
            var cooldown = 1 / tower.ShotsPerSecond;
            tower.ShotCooldown -= game.TimeModel.LastDeltaTime;
            while(tower.ShotCooldown < 0 && GetTargetInRange(game, tower, out Vector3 position))
            {
                tower.ShotCooldown += cooldown;
                var path = new DirectPath(tower.Position, position);
                var projectile = new Projectile()
                {
                    Key = "TowerBomb",
                    Trajectory = new PathFollower(path),
                    MoveSpeed = 5
                };
                game.TowerDefense.Projectiles.AddItem(projectile);
            }
        }

        public bool GetTargetInRange(GameModel game, Tower tower, out Vector3 position)
        {
            if (tower.EnemiesInRange.Count > 0)
            {
                var id = tower.EnemiesInRange.First();
                position = game.Characters.GetItem(id).Position;
                return true;
            } else
            {
                position = Vector3.zero;
                return false;
            }
        }
    }
}
