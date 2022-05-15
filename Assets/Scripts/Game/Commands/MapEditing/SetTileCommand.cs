using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTileCommand : ICommand
{
    public string TileType;
    public Vector2Int Position;
    public void Execute(GameModel model)
    {
        var tileData = DataService.GetData<TileDataCollection>().GetTypeData(TileType);
        model.MapModel.Grid.Map[Position] = new MapTileModel()
        {
            Type = TileType,
            MoveCost = tileData.MoveCost
        };
        model.MapModel.Grid.Id = Guid.NewGuid();
    }
}
