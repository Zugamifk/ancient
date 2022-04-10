using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MapController
{
    public void InitializeModel(MapModel model, BoundsInt dimensions, string tileType)
    {
        int i = 0;
        for (int x = dimensions.xMin; x < dimensions.xMax; x++)
        {
            for (int y = dimensions.yMin; y < dimensions.yMax; y++)
            {
                model.Grid.Map[new Vector2Int(x, y)] = new MapTileModel() { Type = tileType };
            }
        }
        model.Grid.Dimenions = dimensions;
    }

    public void AddBuilding(MapModel model, string name, Vector2Int position)
    {
        var building = new BuildingModel()
        {
            Name = name,
            Position = position
        };
        model.Buildings.Add(building);
        //var entrance = new IntersectionGraphNode()
        //{
        //    Position = building.Position + 
        //}
        
    }

    public void BuildRoad(MapModel model, string startName, string endName)
    {
        var start = model.Buildings.First(b => b.Name == startName);
        var end = model.Buildings.First(b => b.Name == endName);
        model.Graph.Connect(start, end);

        var pointA = Vector2Int.FloorToInt(start.Position);
        var pointB = Vector2Int.FloorToInt(end.Position);
        int xs = Math.Sign(pointB.x - pointA.x);
        int ys = Math.Sign(pointB.y - pointA.y);
        for (int x = pointA.x; x != pointB.x; x += xs)
        {
            model.Grid.Map[new Vector2Int(x, pointA.y)] = new MapTileModel() { Type = Names.Tiles.Road };
        }

        for (int y = pointA.y; y != pointB.y + ys; y += ys)
        {
            model.Grid.Map[new Vector2Int(pointB.x, y)] = new MapTileModel() { Type = Names.Tiles.Road };
        }
    }
}
