using Map.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Map.Services;

public class SetTileCommand : ICommand
{
    Guid _mapId;
    public string TileType;
    public Vector2Int Position;

    public SetTileCommand(Guid mapId) {
        _mapId = mapId;
    }

    public void Execute(GameModel model)
    {
        var tileData = DataService.GetData<TileDataCollection>().GetTypeData(TileType);
        var map = model.Maps.GetItem(_mapId);
        map.Grid.Map[Position] = new MapTileModel()
        {
            Type = TileType,
            MoveCost = tileData.MoveCost
        };
        map.Grid.StateId = Guid.NewGuid();
    }
}
