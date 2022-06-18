using Map.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Map.Services;

namespace SpiritVessel.Services
{
    public class PathGenerator
    {
        static PathFinder _pathFinder = new();
        
        public void GenerateEnemyPaths(MapModel vesselMap)
        {
            Debug.Log("Generated SpiritVessel map");
            GenerateStraightPath(vesselMap, Vector2Int.zero, new Vector2Int(10,10));
        }

        void GenerateStraightPath(MapModel model, Vector2Int pointA, Vector2Int pointB)
        {
            MakePath(model, pointA, pointB, true);
        }

        void MakePath(MapModel model, Vector2Int pointA, Vector2Int pointB, bool direct = false)
        {
            var roadtile = GetTileModel(Name.Tile.Road);
            var path = direct ? _pathFinder.GetDirectPath(pointA, pointB, model.Grid) : _pathFinder.GetPath(pointA, pointB, model.Grid);
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
}
