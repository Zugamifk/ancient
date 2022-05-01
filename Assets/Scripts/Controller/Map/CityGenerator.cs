using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CityGenerator
{
    BuildingCollection _buildingCollection;
    TileDataCollection _tileCollection;
    PathFinder _pathFinder;
    int _roadExtents=10;
    int _roadExtentsVariability = 4;

    public CityGenerator(BuildingCollection buildingcollection, TileDataCollection tileDataCollection, PathFinder pathFinder)
    {
        _buildingCollection = buildingcollection;
        _tileCollection = tileDataCollection;
        _pathFinder = pathFinder;
    }

    public void Generate(MapModel map, PathFinder pathfinder)
    {
        BuildRoad(map, Vector2Int.down, new Vector2Int(
            UnityEngine.Random.Range(_roadExtents - _roadExtentsVariability, _roadExtents + _roadExtentsVariability),
            UnityEngine.Random.Range(_roadExtents - _roadExtentsVariability, _roadExtents + _roadExtentsVariability)));
        BuildRoad(map, Vector2Int.down, new Vector2Int(
            UnityEngine.Random.Range(_roadExtents - _roadExtentsVariability, _roadExtents + _roadExtentsVariability),
            -UnityEngine.Random.Range(_roadExtents - _roadExtentsVariability, _roadExtents + _roadExtentsVariability)));
        BuildRoad(map, Vector2Int.down, new Vector2Int(
            -UnityEngine.Random.Range(_roadExtents - _roadExtentsVariability, _roadExtents + _roadExtentsVariability),
            UnityEngine.Random.Range(_roadExtents - _roadExtentsVariability, _roadExtents + _roadExtentsVariability)));
        BuildRoad(map, Vector2Int.down, new Vector2Int(
            -UnityEngine.Random.Range(_roadExtents - _roadExtentsVariability, _roadExtents + _roadExtentsVariability),
            -UnityEngine.Random.Range(_roadExtents - _roadExtentsVariability, _roadExtents + _roadExtentsVariability)));
    }


    public void BuildRoad(MapModel model, string startName, string endName)
    {
        var start = model.Buildings.GetItem(startName);
        var end = model.Buildings.GetItem(endName);
        model.Graph.Connect(start, end);

        var pointA = Vector2Int.FloorToInt(start.EntrancePosition);
        var pointB = Vector2Int.FloorToInt(end.EntrancePosition);
        BuildRoad(model, pointA, pointB);
    }

    public void BuildRoad(MapModel model, Vector2Int pointA, Vector2Int pointB)
    {
        var roadtile = GetTileModel(Name.Tile.Road);
        var path = _pathFinder.GetPath(pointA, pointB, model.Grid);
        foreach(var p in path.Path)
        {
            model.Grid.Map[p] = roadtile;
        }
    }

    public BuildingModel AddBuilding(MapModel model, string name, Vector2Int position)
    {
        var data = _buildingCollection[name];
        var building = new BuildingModel()
        {
            Name = name,
            Position = position,
            EntrancePosition = position + data.EntranceOffset,
        };
        model.Buildings.AddItem(building, name);
        model.Grid.Map[position] = GetTileModel(Name.Tile.Building);
        return building;
    }

    MapTileModel GetTileModel(string type)
    {
        var tileData = _tileCollection.GetTypeData(type);
        return new MapTileModel()
        {
            Type = type,
            MoveCost = tileData.MoveCost
        };
    }
}
