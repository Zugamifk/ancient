using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PathFinder
{
    public CityPath GetDirectPath(Vector2Int start, Vector2Int end, IMapGridModel grid)
    {
        var path = new CityPath();
        int xs = Math.Sign(end.x-start.x);
        int ys = Math.Sign(end.y-start.y);
        for (int x = start.x; x != end.x; x += xs)
        {
            path.Path.Add(new Vector2Int(x, start.y));
        }

        for (int y = start.y; y != end.y + ys; y += ys)
        {
            path.Path.Add(new Vector2Int(end.x, y));
        }

        return path;
    }

    public CityPath GetPath(Vector2Int start, Vector2Int end, IMapGridModel grid)
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
            while (current != start)
            {
                path.Path.Add(current);
                current = cameFrom[current];
            }
            path.Path.Add(current);
            path.Path.Reverse();
            return path;
        }

        IEnumerable<Vector2Int> GetNeighbours(Vector2Int position)
        {
            yield return new Vector2Int(position.x - 1, position.y);
            yield return new Vector2Int(position.x, position.y + 1);
            yield return new Vector2Int(position.x + 1, position.y);
            yield return new Vector2Int(position.x, position.y - 1);
        }

        int longRunCounter = 10000;  
        while (openSet.Count > 0 && longRunCounter-- > 0)
        {
            var current = openSet.Aggregate((a, b) => GetFScore(a) > GetFScore(b) ? b : a);
            if (current == end)
            {
                return ReconstructPath();
            }

            openSet.Remove(current);
            foreach (var n in GetNeighbours(current))
            {
                var moveCost = grid.InBounds(n) ? grid.GetTile(n).MoveCost : 9999;
                var g = GetGScore(current) + moveCost;
                if (g < GetGScore(n))
                {
                    cameFrom[n] = current;
                    gScore[n] = g;
                    fScore[n] = g + EstimateDistance(n);
                    if (!openSet.Contains(n))
                    {
                        openSet.Add(n);
                    }
                }
            }
        }

        if (longRunCounter <= 0)
        {
            throw new InvalidOperationException($"Path find from {start} to {end} ran long!");
        }

        return null;
    }
}
