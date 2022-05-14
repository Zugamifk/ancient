using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CityGenerator
{
    int _roadExtents=10;
    int _roadExtentsVariability = 4;

    public void Generate(MapModel map)
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
        map.Grid.Id = Guid.NewGuid();
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
        var path = Services.Get<PathFinder>().GetPath(pointA, pointB, model.Grid);
        foreach (var p in path.Path)
        {
            model.Grid.Map[p] = roadtile;
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
