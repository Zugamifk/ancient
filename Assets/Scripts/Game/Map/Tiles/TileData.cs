using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileData
{
    public readonly List<Tile> Tiles = new List<Tile>();
    public readonly string Type;
    public readonly string Left;
    public readonly string Right;
    public readonly string Top;
    public readonly string Bottom;

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
