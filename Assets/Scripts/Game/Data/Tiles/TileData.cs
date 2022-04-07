using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileData : ITileData
{
    public readonly List<Tile> Tiles = new List<Tile>();
    public string Type { get; }
    public string Left { get; }
    public string Right { get; }
    public string Top { get; }
    public string Bottom { get; }

    public TileData(string type, string left, string right, string top, string bottom)
    {
        Type = type;
        Left = left;
        Right = right;
        Top = top;
        Bottom = bottom;
    }

    public Tile GetRandomTile()
    {
        return Tiles[Random.Range(0, Tiles.Count)];
    }
}
