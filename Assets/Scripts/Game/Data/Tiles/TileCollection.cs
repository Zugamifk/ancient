using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileCollection : ITileCollection
{
    Dictionary<(string, string, string, string, string), TileData> _edgeTypeToTileData = new Dictionary<(string, string, string, string, string), TileData>();

    public ITileData GetTileData(string type, string left, string right, string top, string bottom)
    {
        return GetTileData((type, left, right, top, bottom));
    }

    public TileData GetTileData((string, string, string, string, string) key)
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

    public TileCollection(TileSprites sprites)
    {
        foreach (var td in sprites.GroundTiles)
        {
            var type = td.type.ToString();
            var left = td.left.ToString();
            var right = td.right.ToString();
            var top = td.top.ToString();
            var bottom = td.bottom.ToString();
            var key = (type, left, right, top, bottom);
            TileData tileData;
            if (!_edgeTypeToTileData.TryGetValue(key, out tileData))
            {
                tileData = new TileData(type, left, right, top, bottom);
                _edgeTypeToTileData.Add(key, tileData);
            }

            var tile = ScriptableObject.CreateInstance<Tile>();
            tile.sprite = td.sprite;
            tile.colliderType = Tile.ColliderType.None;
            tileData.Tiles.Add(tile);
        }
    }
}
