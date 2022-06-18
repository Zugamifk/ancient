using Map.Data;
using Map.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadMapDataCommand : ICommand
{
    MapModel _map;
    public LoadMapDataCommand(MapModel map)
    {
        _map = map;
    }

    public void Execute(GameModel model)
    {
        var mapData = DataService.GetData<MapData>();
        var dimensions = mapData.Dimensions;
        var x0 = -dimensions.x / 2;
        var xn = dimensions.x / 2;
        var y0 = -dimensions.y / 2;
        var yn = dimensions.y / 2;
        for (int x = x0; x < xn; x++)
        {
            for (int y = y0; y < yn; y++)
            {
                _map.Grid.Map[new Vector2Int(x, y)] = GetTileModel(mapData.DefaultTile);
            }
        }
        _map.Grid.Dimenions = dimensions;
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
