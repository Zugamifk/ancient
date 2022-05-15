using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretDefenseSpawnEnemyCommand : ICommand
{
    Vector2Int _position;
    public TurretDefenseSpawnEnemyCommand(Vector2Int position)
    {
        _position = position;
    }

    public void Execute(GameModel model)
    {
        var tdModel = model.TurretDefenseModel;
        var gamedata = DataService.GetData<TurretDefenseData>();
        var waveData = gamedata.Waves[tdModel.CurrentWave];
        void SpawnedEnemy(CharacterModel enemy)
        {
            tdModel.Enemies.Add(enemy);
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
            Debug.Log("Spawn");
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
        Game.Do(new TurretDefenseEnemyReachEndCommand(model.OwnerId));
    }
}
