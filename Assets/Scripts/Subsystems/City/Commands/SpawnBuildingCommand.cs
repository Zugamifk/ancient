using City.Data;
using City.Model;
using Map.Commands;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace City.Commands
{
    public class SpawnBuildingCommand : ICommand
    {
        static SetTileCommand _setBuildingTile = new();
        CityModel _city;
        string _buildingName;
        Vector2Int _position;
        public SpawnBuildingCommand(CityModel city, string buildingName, Vector2Int position)
        {
            _city = city;
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
            _city.Buildings.AddItem(building, building.Key);
            model.AllIdentifiables.AddItem(building, building.Key);

            _setBuildingTile.Position = _position;
            _setBuildingTile.TileType = Name.Tile.Building;
            _setBuildingTile.Execute(model);
        }
    }
}