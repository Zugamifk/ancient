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
        SpawnWaveUnits(model);
        UpdateTurretTargets(model);
    }

    void SpawnWaveUnits(GameModel model)
    {
        var tdModel = model.TurretDefenseModel;

        if (tdModel.CurrentWave < 0) return;

        tdModel.CurrentTime = model.TimeModel.RealTime - tdModel.StartTime;

        var waveData = _gameData.Waves[tdModel.CurrentWave];
        if (tdModel.SpawnedCount < waveData.Count)
        {
            void SpawnedEnemy(CharacterModel enemy)
            {
                tdModel.Enemies.Add(enemy);
                _commands.DoCommand(new MoveCharacterCommand()
                {
                    CharacterId = enemy.Id,
                    Destination = tdModel.EndPoint,
                    ReachedPathEnd = OnEnemyReachedEnd
                });
            }
            var step = waveData.SpawnTime / waveData.Count;
            var lastSpawnTime = tdModel.StartTime.TotalSeconds + tdModel.SpawnedCount * step;
            var time = model.TimeModel.RealTime.TotalSeconds;
            for (var t = lastSpawnTime; t < time && tdModel.SpawnedCount < waveData.Count; t += step)
            {
                _commands.DoCommand(new SpawnCharacterCommand()
                {
                    Name = waveData.Enemy.Name,
                    Position = tdModel.SpawnPosition,
                    OnSpawned = SpawnedEnemy
                });

                tdModel.SpawnedCount++;
            }
        }
    }

    void UpdateTurretTargets(GameModel model)
    {
        var enemies = model.TurretDefenseModel.Enemies;
        foreach (var turret in model.TurretDefenseModel.Turrets.AllItems)
        {
            turret.EnemiesInRange.Clear();
            foreach(var e in enemies)
            {
                if(Vector2.Distance(e.Position, turret.Position) < turret.AttackRadius)
                {
                    turret.EnemiesInRange.Add(e.Id);
                }
            }
        }
    }

    void UpdateProjectiles(GameModel model)
    {

    }

    public TurretDefenseModel GetNewModel()
    {
        var model = new TurretDefenseModel();
        model.Lives = _gameData.StartingLives;
        model.MaxLives = _gameData.StartingLives;
        model.CurrentWave = -1;
        model.StartPlacingBuilding += StartPlacingBuilding;
        model.StopPlacingBuilding += StopPlacingBuilding;
        model.PlaceBuilding += PlaceBuilding;
        return model;
    }

    public TurretModel GetNewTurretModel(string name)
    {
        var data = _gameData.GetTurret(name);
        var model = new TurretModel();
        model.Name = data.Name;
        model.AttackRadius = data.Radius;
        return model;
    }

    #region ViewModel events
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
        _commands.DoCommand(new TurretDefenseBuildTurretCommand(model.BuildingBeingPlaced, position));
        StopPlacingBuilding(model);
    }
    #endregion
}
