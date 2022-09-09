using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TowerDefense.Models;
using Model;

namespace TowerDefense.Commands
{
    public class DamageAreaCommand : ICommand
    {
        Vector2 _position;
        float _radius;
        public DamageAreaCommand(Vector2 position, float radius)
        {
            _position = position;
            _radius = radius;
        }

        public void Execute(GameModel model)
        {
            var towerDefenseModel = model.GetModel<TowerDefenseGameModel>();
            foreach (var e in towerDefenseModel.EnemyIds.Select(model.Characters.GetItem))
            {
                if (Vector2.Distance(e.Position, _position) < _radius)
                {
                    Game.Do(new StopHeartCommand(e.Id));
                }
            }
        }
    }
}
