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

    public void ConfigureModel(TurretDefenseModel model)
    {
        model.StartPlacingBuilding += StartPlacingBuilding;
        model.StopPlacingBuilding += StopPlacingBuilding;
        model.PlaceBuilding += PlaceBuilding;
    }

    public void Update(GameModel model)
    {
        var tdModel = model.TurretDefenseModel;
        
        if (tdModel.CurrentWave < 0) return;

        tdModel.CurrentTime = model.TimeModel.RealTime - tdModel.StartTime;

        var waveData = _gameData.Waves[tdModel.CurrentWave];
        if(tdModel.SpawnedCount < waveData.Count)
        {
            void SpawnedEnemy(CharacterModel enemy)
            {
                tdModel.Enemies.Add(enemy);
                _commands.DoCommand(new MoveCharacterCommand() { 
                    CharacterId = enemy.Id,
                    Destination = tdModel.EndPoint,
                    ReachedPathEnd = OnEnemyReachedEnd
                });
            }
            var step = waveData.SpawnTime / waveData.Count;
            var lastSpawnTime = tdModel.StartTime.TotalSeconds + tdModel.SpawnedCount * step;
            var time = model.TimeModel.RealTime.TotalSeconds;
            for(var t = lastSpawnTime; t < time && tdModel.SpawnedCount < waveData.Count; t += step)
            {
                _commands.DoCommand(new SpawnCharacterCommand()
                {
                    Name = waveData.Enemy.Name,
                    Position = tdModel.SpawnPosition,
                    OnSpawned = SpawnedEnemy
                });
                
                tdModel.SpawnedCount ++;
            }
        }
    }

    public void StartGame(TurretDefenseModel model, GameModel gameModel, Vector2Int startPosition, Vector2Int endPosition)
    {
        model.Lives = _gameData.StartingLives;
        model.MaxLives = _gameData.StartingLives;
        model.SpawnPosition = startPosition;
        model.EndPoint = endPosition;
        model.CurrentWave = -1;
    }

    public void StartWave(TurretDefenseModel model, GameModel gameModel)
    {
        model.StartTime = gameModel.TimeModel.RealTime;
        model.SpawnedCount = 0;
        model.CurrentWave++;
    }

    public void LoseGame(TurretDefenseModel model)
    {
        model.CurrentWave = -1;
        Debug.Log("Game over!!");
    }

    void OnEnemyReachedEnd(MovementModel model)
    {
        _commands.DoCommand(new RemoveCharacterCommand()
        {
            CharacterId = model.OwnerId
        });
        _commands.DoCommand(new TurretDefenseLoseLifeCommand());
    }

    void StartPlacingBuilding(TurretDefenseModel model, string name)
    {
        model.BuildingBeingPlaced = name;
    }

    void StopPlacingBuilding(TurretDefenseModel model)
    {
        model.BuildingBeingPlaced = null;
    }

    void PlaceBuilding(TurretDefenseModel model, Vector2Int position)
    {
        _commands.DoCommand(new SpawnBuildingCommand(model.BuildingBeingPlaced, position));
        StopPlacingBuilding(model);
    }
}
