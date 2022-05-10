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

    public void Execute(GameController controller)
    {
        var model = controller.TurretDefenseController.GetNewModel();
        model.SpawnPosition = _spawnPosition;
        model.EndPoint = _destination;
        controller.Model.TurretDefenseModel = model;
    }
}
