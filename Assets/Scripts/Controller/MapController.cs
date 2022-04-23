using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MapController
{
    ICommandService _commands;
    BuildingCollection _buildingCollection;
    TileDataCollection _tileCollection;
    MapData _mapData;

    public MapController(ICommandService commands, TileDataCollection tileCollection, BuildingCollection buildingCollection, MapData mapData)
    {
        _commands = commands;
        _buildingCollection = buildingCollection;
        _tileCollection = tileCollection;
        _mapData = mapData;
    }

    public void InitializeModel(MapModel model)
    {
        var dimensions = _mapData.Dimensions;
        for (int x = dimensions.xMin; x < dimensions.xMax; x++)
        {
            for (int y = dimensions.yMin; y < dimensions.yMax; y++)
            {
                model.Grid.Map[new Vector2Int(x, y)] = GetTileModel(_mapData.DefaultTile);
            }
        }
        model.Grid.Dimenions = dimensions;
    }

    public void AddBuilding(MapModel model, string name, Vector2Int position)
    {
        var data = _buildingCollection[name];
        var building = new BuildingModel()
        {
            Name = name,
            Position = position,
            EntrancePosition = position + data.EntranceOffset,
        };
        building.Clicked += ClickedBuilding;
        model.Buildings.Add(building);
    }

    void ClickedBuilding(object sender, int button)
    {
        var building = (IBuildingModel)sender;
        _commands.DoCommand(new MoveAgentCommand("TestAgent", building.Name));
    }

    public void BuildRoad(MapModel model, string startName, string endName)
    {
        var start = model.Buildings.First(b => b.Name == startName);
        var end = model.Buildings.First(b => b.Name == endName);
        model.Graph.Connect(start, end);

        var pointA = Vector2Int.FloorToInt(start.EntrancePosition);
        var pointB = Vector2Int.FloorToInt(end.EntrancePosition);
        int xs = Math.Sign(pointB.x - pointA.x);
        int ys = Math.Sign(pointB.y - pointA.y);
        var roadtile = GetTileModel(Name.Tile.Road);
        for (int x = pointA.x; x != pointB.x; x += xs)
        {
            model.Grid.Map[new Vector2Int(x, pointA.y)] = roadtile;
        }

        for (int y = pointA.y; y != pointB.y + ys; y += ys)
        {
            model.Grid.Map[new Vector2Int(pointB.x, y)] = roadtile;
        }
    }

    public void SetTile(MapModel model, int x, int y, string type)
    {
        var tile = GetTileModel(type);
        model.Grid.Map[new Vector2Int(x, y)] = tile;
    }

    public CityPath GetPath(Vector2Int start, Vector2Int end, MapGridModel grid)
    {
        int EstimateDistance(Vector2Int point)
        {
            return Mathf.Abs(end.x - point.x) + Mathf.Abs(end.y - point.y);
        }

        List<Vector2Int> openSet = new List<Vector2Int>();
        openSet.Add(start);

        Dictionary<Vector2Int, Vector2Int> cameFrom = new Dictionary<Vector2Int, Vector2Int>();

        Dictionary<Vector2Int, int> gScore = new Dictionary<Vector2Int, int>();
        gScore[start] = 0;

        int GetGScore(Vector2Int p)
        {
            int score;
            if (!gScore.TryGetValue(p, out score))
            {
                score = int.MaxValue;
                gScore[p] = score;
            }
            return score;
        }

        Dictionary<Vector2Int, int> fScore = new Dictionary<Vector2Int, int>();
        fScore[start] = EstimateDistance(start);

        int GetFScore(Vector2Int p)
        {
            int score;
            if (!fScore.TryGetValue(p, out score))
            {
                score = int.MaxValue;
                fScore[p] = score;
            }
            return score;
        }

        CityPath ReconstructPath()
        {
            var path = new CityPath();
            var current = end;
            while(current!=start)
            {
                path.Path.Add(current);
                current = cameFrom[current];
            }
            path.Path.Reverse();
            return path;
        }

        IEnumerable<Vector2Int> GetNeighbours(Vector2Int position)
        {
            yield return new Vector2Int(position.x - 1, position.y);
            yield return new Vector2Int(position.x, position.y+1);
            yield return new Vector2Int(position.x + 1, position.y);
            yield return new Vector2Int(position.x, position.y-1);
        }

        while (openSet.Count > 0)
        {
            var current = openSet.Aggregate((a, b) => GetFScore(a) > GetFScore(b) ? b : a);
            if(current == end)
            {
                return ReconstructPath();
            }

            openSet.Remove(current);
            foreach(var n in GetNeighbours(current))
            {
                var g = GetGScore(current) + grid.Map[n].MoveCost;
                if(g < GetGScore(n))
                {
                    cameFrom[n] = current;
                    gScore[n] = g;
                    fScore[n] = g + EstimateDistance(n);
                    if(!openSet.Contains(n))
                    {
                        openSet.Add(n);
                    }
                }
            }
        }

        return null;
    }

    MapTileModel GetTileModel(string type)
    {
        var tileData = _tileCollection.GetTypeData(type);
        return new MapTileModel()
        {
            Type = type,
            MoveCost = tileData.MoveCost
        };
    }
}
