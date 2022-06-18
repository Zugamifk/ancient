using Map.Data;
using Map.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadMapDataCommand : ICommand
{
    Guid _mapId;
    public LoadMapDataCommand(Guid mapId)
    {
        _mapId = mapId;
    }

    public void Execute(GameModel model)
    {
        var mapData = DataService.GetData<MapData>();
        var map = model.Maps.GetItem(_mapId);
        var dimensions = mapData.Dimensions;
        var x0 = -dimensions.x / 2;
        var xn = dimensions.x / 2;
        var y0 = -dimensions.y / 2;
        var yn = dimensions.y / 2;
        for (int x = x0; x < xn; x++)
        {
            for (int y = y0; y < yn; y++)
            {
                map.Grid.Map[new Vector2Int(x, y)] = GetTileModel(mapData.DefaultTile);
            }
        }
        map.Grid.Dimenions = dimensions;
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