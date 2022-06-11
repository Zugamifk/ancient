using Map.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Map.Services;

namespace Map.Commands
{
    public class SetTileCommand : ICommand, IMapCommand
    {
        public string TileType;
        public Vector2Int Position;

        public MapModel MapModel { private get; set; }

        public void Execute(GameModel model)
        {
            var tileData = DataService.GetData<TileDataCollection>().GetTypeData(TileType);
            MapModel.Grid.Map[Position] = new MapTileModel()
            {
                Type = TileType,
                MoveCost = tileData.MoveCost
            };
            MapModel.Grid.Id = Guid.NewGuid();
        }
    }
}