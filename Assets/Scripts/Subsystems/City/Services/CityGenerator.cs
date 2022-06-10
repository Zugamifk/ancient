using City.Model;
using Map.Model;
using Map.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace City.Services
{
    public class CityGenerator
    {
        PathFinder _pathFinder = new();
        int _roadExtents = 10;
        int _roadExtentsVariability = 4;

        public void Generate(CityModel map)
        {
            //BuildRoad(map, Vector2Int.down, new Vector2Int(
            //    UnityEngine.Random.Range(_roadExtents - _roadExtentsVariability, _roadExtents + _roadExtentsVariability),
            //    UnityEngine.Random.Range(_roadExtents - _roadExtentsVariability, _roadExtents + _roadExtentsVariability)));
            //BuildRoad(map, Vector2Int.down, new Vector2Int(
            //    UnityEngine.Random.Range(_roadExtents - _roadExtentsVariability, _roadExtents + _roadExtentsVariability),
            //    -UnityEngine.Random.Range(_roadExtents - _roadExtentsVariability, _roadExtents + _roadExtentsVariability)));
            //BuildRoad(map, Vector2Int.down, new Vector2Int(
            //    -UnityEngine.Random.Range(_roadExtents - _roadExtentsVariability, _roadExtents + _roadExtentsVariability),
            //    UnityEngine.Random.Range(_roadExtents - _roadExtentsVariability, _roadExtents + _roadExtentsVariability)));
            //BuildRoad(map, Vector2Int.down, new Vector2Int(
            //    -UnityEngine.Random.Range(_roadExtents - _roadExtentsVariability, _roadExtents + _roadExtentsVariability),
            //    -UnityEngine.Random.Range(_roadExtents - _roadExtentsVariability, _roadExtents + _roadExtentsVariability)));
            //Game.Do(new SpawnBuildingCommand(Name.Building.Manor, Vector2Int.zero));
            //Game.Do(new SpawnBuildingCommand(Name.Building.House, new Vector2Int(5, 2)));
            //Game.Do(new BuildRoadCommand(Name.Building.Manor, Name.Building.House));
            //map.Grid.Id = Guid.NewGuid();
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
            var roadtile = GetTileModel(Name.Tile.Road);
            var path = direct ? _pathFinder.GetDirectPath(pointA, pointB, model.Map.Grid) : _pathFinder.GetPath(pointA, pointB, model.Map.Grid);
            foreach (var p in path.Path)
            {
                model.Map.Grid.Map[p] = roadtile;
            }
        }

        MapTileModel GetTileModel(string type)
        {
            var tileData = DataService.GetData<TileDataCollection>().GetTypeData(type);
            return new MapTileModel()
            {
                Type = type,
                MoveCost = tileData.MoveCost
            };
        }
    }
}