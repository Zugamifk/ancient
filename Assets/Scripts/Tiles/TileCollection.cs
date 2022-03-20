using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileCollection
{
    Dictionary<(string, string, string, string, string), TileData> _edgeTypeToTileData = new Dictionary<(string, string, string, string, string), TileData>();

    public TileData this[string type, string left, string right, string top, string bottom] => this[(type, left, right, top, bottom)];

    public TileData this[(string, string, string, string, string) key]
    {
        get
        {
            TileData tileData;
            if (_edgeTypeToTileData.TryGetValue(key, out tileData))
            {
                return tileData;
            }
            else
            {
                return null;
            }
        }
    }

    public TileCollection(TileSprites sprites)
    {
        foreach(var td in sprites.GroundTiles)
        {
            var type = td.type.ToString();
            var left = td.left.ToString();
            var right = td.right.ToString();
            var top = td.top.ToString();
            var bottom = td.bottom.ToString();
            var key = (type, left, right, top, bottom);
            TileData tileData;
            if(!_edgeTypeToTileData.TryGetValue(key, out tileData))
            {
                tileData = new TileData(type, left, right, top, bottom);
                _edgeTypeToTileData.Add(key, tileData);
            }

            var tile = ScriptableObject.CreateInstance<Tile>();
            tile.sprite = td.sprite;
            tileData.Tiles.Add(tile);
        }
    }
}
