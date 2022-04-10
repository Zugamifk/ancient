using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileDataCollection : ScriptableObject, ITileBuilder
{
    public TileTypeData[] Tiles;

    public Tile GetTile(string type, string left, string top, string right, string bottom)
    {
        throw new System.NotImplementedException();
    }
}
