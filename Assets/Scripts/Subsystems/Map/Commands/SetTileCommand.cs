using Map.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Map.Commands
{
    public class SetTileCommand : ICommand
    {
        public string TileType;
        public Vector2Int Position;
        public MapModel Map;

        public void Execute(GameModel model)
        {
            var tileData = DataService.GetData<TileDataCollection>().GetTypeData(TileType);
            Map.Grid.Map[Position] = new MapTileModel()
            {
                Type = TileType,
                MoveCost = tileData.MoveCost
            };
            Map.Grid.Id = Guid.NewGuid();
        }
    }
}