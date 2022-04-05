using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public interface ITileData
{
    string Type { get; }
    Tile GetRandomTile();
}
