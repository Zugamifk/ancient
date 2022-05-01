using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MapController
{
    ICommandService _commands;
    BuildingCollection _buildingCollection;
    TileDataCollection _tileCollection;
    MapData _mapData;
    CityGenerator _cityGenerator;
    PathFinder _pathfinder = new PathFinder();
    public CityGenerator CityGenerator => _cityGenerator;
    public PathFinder PathFinder => _pathfinder;
    public MapController(ICommandService commands, TileDataCollection tileCollection, BuildingCollection buildingCollection, MapData mapData)
    {
        _commands = commands;
        _buildingCollection = buildingCollection;
        _tileCollection = tileCollection;
        _cityGenerator = new CityGenerator(_buildingCollection, _tileCollection, _pathfinder);
        _mapData = mapData;
    }

    public void InitializeModel(MapModel model)
    {
        var dimensions = _mapData.Dimensions;
        var x0 = -dimensions.x / 2;
        var xn = dimensions.x / 2;
        var y0 = -dimensions.y / 2;
        var yn = dimensions.y / 2;
        for (int x = x0; x < xn; x++)
        {
            for (int y = y0; y < yn; y++)
            {
                model.Grid.Map[new Vector2Int(x, y)] = GetTileModel(_mapData.DefaultTile);
            }
        }
        model.Grid.Dimenions = dimensions;
    }

    public void AddBuilding(MapModel model, string name, Vector2Int position)
    {
        var building = _cityGenerator.AddBuilding(model, name, position);
    }

    public void SetTile(MapModel model, int x, int y, string type)
    {
        var tile = GetTileModel(type);
        model.Grid.Map[new Vector2Int(x, y)] = tile;
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