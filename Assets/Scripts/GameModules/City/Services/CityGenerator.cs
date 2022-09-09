using City.Data;
using City.Model;
using Map.Model;
using Map.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Model;

namespace City.Services
{
    public class CityGenerator
    {
        PathFinder _pathFinder = new();
        int _roadExtents = 10;
        int _roadExtentsVariability = 4;

        public void Generate(CityModel city)
        {
            BuildRoad(city, Vector2Int.down, new Vector2Int(
                UnityEngine.Random.Range(_roadExtents - _roadExtentsVariability, _roadExtents + _roadExtentsVariability),
                UnityEngine.Random.Range(_roadExtents - _roadExtentsVariability, _roadExtents + _roadExtentsVariability)));
            BuildRoad(city, Vector2Int.down, new Vector2Int(
                UnityEngine.Random.Range(_roadExtents - _roadExtentsVariability, _roadExtents + _roadExtentsVariability),
                -UnityEngine.Random.Range(_roadExtents - _roadExtentsVariability, _roadExtents + _roadExtentsVariability)));
            BuildRoad(city, Vector2Int.down, new Vector2Int(
                -UnityEngine.Random.Range(_roadExtents - _roadExtentsVariability, _roadExtents + _roadExtentsVariability),
                UnityEngine.Random.Range(_roadExtents - _roadExtentsVariability, _roadExtents + _roadExtentsVariability)));
            BuildRoad(city, Vector2Int.down, new Vector2Int(
                -UnityEngine.Random.Range(_roadExtents - _roadExtentsVariability, _roadExtents + _roadExtentsVariability),
                -UnityEngine.Random.Range(_roadExtents - _roadExtentsVariability, _roadExtents + _roadExtentsVariability)));
            AddBuilding(city, Name.Building.Manor, Vector2Int.zero);
            AddBuilding(city, Name.Building.House, new Vector2Int(5, 2));
            BuildRoad(city, Name.Building.Manor, Name.Building.House);
            city.MapModel.Grid.StateId = Guid.NewGuid();
        }

        public void AddBuilding(CityModel city, string buildingName, Vector2Int position)
        {
            var buildingData = DataService.GetData<BuildingCollection>()[buildingName];
            var building = new BuildingModel()
            {
                Key = buildingData.Name,
                Position = position,
                EntrancePosition = position + buildingData.EntranceOffset,
            };
            city.Buildings.AddItem(building);

            var tileset = DataService.GetData<MapDataCollection>().GetData(city.MapModel.Key).TileSet;
            city.MapModel.Grid.Map[position] = GetTileModel(tileset, Name.Tile.Building);
        }

        public void BuildRoad(CityModel model, string startName, string endName)
        {
            var start = model.Buildings.GetItem(startName);
            var end = model.Buildings.GetItem(endName);
            model.Graph.Connect(start, end);

            var pointA = Vector2Int.FloorToInt(start.EntrancePosition);
            var pointB = Vector2Int.FloorToInt(end.EntrancePosition);
            BuildRoad(model, pointA, pointB, false);
        }

        public void BuildRoad(CityModel model, Vector2Int pointA, Vector2Int pointB, bool direct = false)
        {
            var tileset = DataService.GetData<MapDataCollection>().GetData(model.MapModel.Key).TileSet;
            var roadtile = GetTileModel(tileset, Name.Tile.Road);
            var path = direct ? _pathFinder.GetDirectPath(pointA, pointB, model.MapModel.Grid) : _pathFinder.GetPath(pointA, pointB, model.MapModel.Grid);
            foreach (var p in path.Path)
            {
                model.MapModel.Grid.Map[p] = roadtile;
            }
        }

        MapTileModel GetTileModel(TileSet tileSet, string type)
        {
            var tileData = tileSet.GetTypeData(type);
            return new MapTileModel()
            {
                Type = type,
                MoveCost = tileData.MoveCost
            };
        }
    }
}