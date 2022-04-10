using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileTypeData : ScriptableObject
{
    public string Type;
    public int MoveCost;
    public TileData[] Tiles;

    Dictionary<(string, string, string, string), TileData> _bordersToData = new Dictionary<(string, string, string, string), TileData>();

    private void OnEnable()
    {
        foreach(var data in Tiles)
        {
            _bordersToData[(data.Left, data.Top, data.Right, data.Bottom)] = data;
        }
    }

    public TileData GetTileData(string left, string top, string right, string bottom)
    {
        return _bordersToData[(left, top, right, bottom)];
    }
}
