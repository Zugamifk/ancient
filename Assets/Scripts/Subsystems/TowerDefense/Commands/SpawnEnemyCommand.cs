using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TowerDefense.Data;

namespace TowerDefense.Commands
{
    public class SpawnEnemyCommand : ICommand
    {
        Vector2Int _position;
        public SpawnEnemyCommand(Vector2Int position)
        {
            _position = position;
        }

        public void Execute(GameModel model)
        {
            var tdModel = model.TowerDefense;
            var gamedata = DataService.GetData<TowerDefenseData>();
            var waveData = gamedata.Waves[tdModel.CurrentWave];
            void SpawnedEnemy(CharacterModel enemy)
            {
                tdModel.EnemyIds.Add(enemy.Id);
                Game.Do(new MoveCharacterCommand()
                {
                    CharacterId = enemy.Id,
                    Destination = tdModel.EndPoint,
                    ReachedPathEnd = EnemyReachEnd
                });
            }
            var step = waveData.SpawnTime / waveData.Count;
            var lastSpawnTime = tdModel.StartTime.TotalSeconds + tdModel.SpawnedCount * step;
            var time = model.TimeModel.RealTime.TotalSeconds;
            for (var t = lastSpawnTime; t < time && tdModel.SpawnedCount < waveData.Count; t += step)
            {
                Game.Do(new SpawnCharacterCommand()
                {
                    Name = waveData.Enemy.Name,
                    Position = _position,
                    OnSpawned = SpawnedEnemy
                });

                tdModel.SpawnedCount++;
            }
        }

        void EnemyReachEnd(MovementModel model)
        {
            Game.Do(new EnemyReachEndCommand(model.OwnerId));
        }
    }
}