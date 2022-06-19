using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapData : ScriptableObject
{
    public string Key;
    public Vector2Int Dimensions;
    public TileSet TileSet;
    public string DefaultTile;
}
