using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TowerDefense.Data;
using TowerDefense.Models;
using TowerDefense.ViewModel;

namespace TowerDefense.Commands
{
    public class SpawnEnemyCommand : SpawnCharacterCommand
    {
        public SpawnEnemyCommand(string name, Vector2 position)
            : base(name, position, Game.Model.GetModel<ITowerDefense>().Map.Id)
        {
        }

        protected override void OnSpawnedCharacter(GameModel model, CharacterModel character)
        {
            var tdModel = model.GetModel<TowerDefenseGameModel>();
            tdModel.EnemyIds.Add(character.Id);
            Game.Do(new MoveCharacterCommand()
            {
                CharacterId = character.Id,
                Destination = tdModel.EndPoint,
                ReachedPathEnd = EnemyReachEnd
            });
        }

        void EnemyReachEnd(MovementModel model)
        {
            Game.Do(new EnemyReachEndCommand(model.OwnerId));
        }
    }
}