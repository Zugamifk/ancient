using Map.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Map.Services;

namespace Map.Commands
{
    public class SetTileCommand : ICommand, IMapModelMutator
    {
        public string TileType;
        public Vector2Int Position;
        IMutableMapHandle _mapHandle;

        public SetTileCommand() { }

        public void Execute(GameModel model)
        {
            var tileData = DataService.GetData<TileDataCollection>().GetTypeData(TileType);
            _mapHandle.Map.Grid.Map[Position] = new MapTileModel()
            {
                Type = TileType,
                MoveCost = tileData.MoveCost
            };
            _mapHandle.Map.Grid.Id = Guid.NewGuid();
        }

        public void SetMapHandle(IMutableMapHandle mapHandle)
        {
            _mapHandle = mapHandle;
        }
    }
}