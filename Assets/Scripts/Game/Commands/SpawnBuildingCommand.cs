using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBuildingCommand : ICommand
{
    static SetTileCommand _setBuildingTile = new();
    string _buildingName;
    Vector2Int _position;
    public SpawnBuildingCommand(string buildingName, Vector2Int position)
    {
        _buildingName = buildingName;
        _position = position;
    }

    public void Execute(GameModel model)
    {
        var buildingData = DataService.GetData<BuildingCollection>()[_buildingName];
        var building = new BuildingModel()
        {
            Key = buildingData.Name,
            Position = _position,
            EntrancePosition = _position + buildingData.EntranceOffset,
        };
        model.MapModel.Buildings.AddItem(building, building.Key);
        _setBuildingTile.Position = _position;
        _setBuildingTile.TileType = Name.Tile.Building;
        _setBuildingTile.Execute(model);
    }
}
