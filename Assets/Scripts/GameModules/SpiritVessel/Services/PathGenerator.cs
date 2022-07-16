using Map.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Map.Services;
using System;

namespace SpiritVessel.Services
{
    public class PathGenerator
    {
        static PathFinder _pathFinder = new();
        
        public void GenerateEnemyPaths(MapModel vesselMap)
        {
            //GenerateStraightPath(vesselMap, Vector2Int.zero, new Vector2Int(10,10));
            vesselMap.Grid.StateId = Guid.NewGuid();
        }

        void GenerateStraightPath(MapModel model, Vector2Int pointA, Vector2Int pointB)
        {
            MakePath(model, pointA, pointB, true);
        }

        void MakePath(MapModel model, Vector2Int pointA, Vector2Int pointB, bool direct = false)
        {
            var mapDataLookup = DataService.GetData<MapDataCollection>();
            var mapData = mapDataLookup.GetData(model.Key);
            var roadtile = GetTileModel(mapData.TileSet, Name.Tile.Road);
            var path = direct ? _pathFinder.GetDirectPath(pointA, pointB, model.Grid) : _pathFinder.GetPath(pointA, pointB, model.Grid);
            foreach (var p in path.Path)
            {
                model.Grid.Map[p] = roadtile;
            }
            model.Grid.StateId = Guid.NewGuid();
        }

        MapTileModel GetTileModel(TileSet tileSet, string type)
        {
            var tileData = tileSet.GetTypeData(type);
            return new MapTileModel()
            {
                Type = type,
                MoveCost = tileData.MoveCost
            };
        }
    }
}
