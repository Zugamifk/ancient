using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretDefenseStartGameCommand : ICommand
{
    Vector2Int _spawnPosition;
    Vector2Int _destination;
    public TurretDefenseStartGameCommand(Vector2Int spawnPosition, Vector2Int destination)
    {
        _spawnPosition = spawnPosition;
        _destination = destination;
    }

    public void Execute(GameModel model)
    {
        var turretDefenseData = DataService.GetData<TurretDefenseData>();
        var turretDefenseModel = new TurretDefenseModel();
        turretDefenseModel.Lives = turretDefenseData.StartingLives;
        turretDefenseModel.MaxLives = turretDefenseData.StartingLives;
        turretDefenseModel.CurrentWave = -1;
        turretDefenseModel.EndPoint = _destination;
        model.TurretDefenseModel = turretDefenseModel;
    }
}
