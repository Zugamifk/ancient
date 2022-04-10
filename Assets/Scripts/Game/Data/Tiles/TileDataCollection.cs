using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileDataCollection : ScriptableObject, ITileBuilder
{
    public TileTypeData[] Tiles;

    Dictionary<(string, string, string, string, string), List<Tile>> _tileCache = new Dictionary<(string, string, string, string, string), List<Tile>>();

    public Tile GetTile(string type, string left, string top, string right, string bottom)
    {
        var key = (type, left, top, right, bottom);
        List<Tile> tiles;
        if(!_tileCache.TryGetValue(key, out tiles))
        {
            tiles = BuildNewTileList(key);
        }
        return tiles[Random.Range(0, tiles.Count)];
    }

    List<Tile> BuildNewTileList((string, string, string, string, string) key)
    {
        try
        {
            var list = new List<Tile>();
            var (type, left, top, right, bottom) = key;
            var typeData = Tiles.First(t => t.Type == type);
            var tileData = typeData.GetTileData(left, top, right, bottom);
            foreach (var sprite in tileData.Sprites)
            {
                var tile = CreateInstance<Tile>();
                tile.sprite = sprite;
                tile.colliderType = Tile.ColliderType.None;
                list.Add(tile);
            }
            _tileCache.Add(key, list);
            return list;
        } catch
        {
            Debug.LogError($"Failed to get a tile list for " + key);
            throw;
        }
    }
}
