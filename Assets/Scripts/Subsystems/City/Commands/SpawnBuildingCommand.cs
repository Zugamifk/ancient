using City.Data;
using City.Model;
using City.Services;
using Map.Commands;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace City.Commands
{
    public class SpawnBuildingCommand : ICommand
    {
        static CityGenerator _cityGenerator = new();
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
            _cityGenerator.AddBuilding(_buildingName, _position);
        }
    }
}