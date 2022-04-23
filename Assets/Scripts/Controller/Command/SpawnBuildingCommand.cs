using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBuildingCommand : ICommand
{
    string _buildingName;
    Vector2Int _position;
    public SpawnBuildingCommand(string buildingName, Vector2Int position)
    {
        _buildingName = buildingName;
        _position = position;
    }

    public void Execute(GameController controller)
    {
        controller.MapController.AddBuilding(controller.Model.MapModel, _buildingName, _position);
    }
}
