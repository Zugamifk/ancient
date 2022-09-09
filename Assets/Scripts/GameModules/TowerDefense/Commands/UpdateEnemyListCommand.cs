using Health;
using System.Collections;
using System.Collections.Generic;
using TowerDefense.Data;
using UnityEngine;
using TowerDefense.Models;
using Model;

namespace TowerDefense.Commands
{
    public class UpdateEnemyListCommand : ICommand
    {
        public void Execute(GameModel model)
        {
            var towerDefenseModel = model.GetModel<TowerDefenseGameModel>();
            towerDefenseModel.EnemyIds.RemoveAll(id => !model.Characters.HasId(id));

            var enemyData = DataService.GetData<EnemyDataCollection>();
            foreach (var id in towerDefenseModel.EnemyIds)
            {
                var character = model.Characters.GetItem(id);
                if (!character.Health.Body.IsAlive())
                {
                    Game.Do(new RemoveCharacterCommand(id));
                    var data = enemyData.GetEnemy(character.Key);
                    Game.Do(new AddCoinsCommand(data.CoidReward));
                }
            }
        }
    }
}
