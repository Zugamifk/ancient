using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretDefenseController
{
    ICommandService _commands;
    TurretDefenseData _gameData;

    public TurretDefenseController(ICommandService commands, TurretDefenseData data)
    {
        _commands = commands;
        _gameData = data;
    }

    public void Update(GameModel model)
    {
        var tdModel = model.TurretDefenseModel;
        var waveData = _gameData.Waves[tdModel.CurrentWave];
        if(tdModel.CurrentWave >= 0 && tdModel.SpawnedCount < waveData.Count)
        {
            var step = waveData.SpawnTime / waveData.Count;
            var lastSpawnTime = tdModel.SpawnedCount * step;
            var time = model.TimeModel.Time;
            for(var t = lastSpawnTime; t < time && tdModel.SpawnedCount < waveData.Count; t += step)
            {
                _commands.DoCommand(new TurretDefenseSpawnEnemyCommand(waveData.Enemy.Name, tdModel.SpawnPosition));
                tdModel.SpawnedCount ++;
            }
        }
    }

    public void StartGame(TurretDefenseModel waveModel, GameModel gameModel, Vector2Int startPosition, Vector2Int endPosition)
    {
        waveModel.Lives = _gameData.StartingLives;
        waveModel.SpawnPosition = startPosition;
        waveModel.EndPoint = endPosition;
        waveModel.CurrentWave = -1;
    }

    public void StartWave(TurretDefenseModel waveModel, GameModel gameModel)
    {
        waveModel.SpawnedCount = 0;
        waveModel.CurrentWave++;
    }
}
