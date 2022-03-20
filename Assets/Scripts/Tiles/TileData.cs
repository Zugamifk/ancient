using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileData
{
    public List<Tile> Tiles = new List<Tile>();
    public ETileEdge Left;
    public ETileEdge Right;
    public ETileEdge Top;
    public ETileEdge Bottom;

    public Tile GetRandomTile()
    {
        return Tiles[Random.Range(0, Tiles.Count)];
    }
}
