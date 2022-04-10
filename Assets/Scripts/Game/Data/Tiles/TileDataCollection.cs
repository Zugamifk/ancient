using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileDataCollection : ScriptableObject, ITileBuilder
{
    public TileTypeData[] Tiles;

    Dictionary<(string, string, string, string, string), List<Tile>> _tileCache = new Dictionary<(string, string, string, string, string), List<Tile>>();

    void OnEnable()
    {
        foreach (var typeData in Tiles)
        {
            var type = typeData.Type;
            foreach (var tileData in typeData.Tiles)
            {
                var list = BuildNewTileList(tileData);
                _tileCache.Add((type, tileData.Left, tileData.Top, tileData.Right, tileData.Bottom), list);
            }
        }
    }

    public Tile GetTile(string type, string left, string top, string right, string bottom)
    {
        var key = (type, left, top, right, bottom);
        List<Tile> tiles;
        if (!_tileCache.TryGetValue(key, out tiles))
        {
            tiles = GetWildCardList(key);
        }
        return tiles[Random.Range(0, tiles.Count)];
    }

    List<Tile> GetWildCardList((string, string, string, string, string) key)
    {
        List<Tile> tiles;
        foreach (var wild in GetWildcardKeys(key))
        {
            if (_tileCache.TryGetValue(wild, out tiles))
            {
                _tileCache[key] = tiles;
                return tiles;
            }
        }
        return null;
    }

    List<Tile> BuildNewTileList(TileData tileData)
    {
        var list = new List<Tile>();
        foreach (var sprite in tileData.Sprites)
        {
            var tile = CreateInstance<Tile>();
            tile.sprite = sprite;
            tile.colliderType = Tile.ColliderType.None;
            list.Add(tile);
        }
        return list;
    }

    IEnumerable<(string, string, string, string, string)> GetWildcardKeys((string, string, string, string, string) key)
    {
        var (type, left, top, right, bottom) = key;
        yield return (type, left, top, right, bottom);
        yield return (type, left, top, right, "*");
        yield return (type, left, top, "*", bottom);
        yield return (type, left, top, "*", "*");
        yield return (type, left, "*", right, bottom);
        yield return (type, left, "*", right, "*");
        yield return (type, left, "*", "*", bottom);
        yield return (type, left, "*", "*", "*");
        yield return (type, "*", top, right, bottom);
        yield return (type, "*", top, right, "*");
        yield return (type, "*", top, "*", bottom);
        yield return (type, "*", top, "*", "*");
        yield return (type, "*", "*", right, bottom);
        yield return (type, "*", "*", right, "*");
        yield return (type, "*", "*", "*", bottom);
        yield return (type, "*", "*", "*", "*");
        yield return ("*", left, top, right, bottom);
        yield return ("*", left, top, right, "*");
        yield return ("*", left, top, "*", bottom);
        yield return ("*", left, top, "*", "*");
        yield return ("*", left, "*", right, bottom);
        yield return ("*", left, "*", right, "*");
        yield return ("*", left, "*", "*", bottom);
        yield return ("*", left, "*", "*", "*");
        yield return ("*", "*", top, right, bottom);
        yield return ("*", "*", top, right, "*");
        yield return ("*", "*", top, "*", bottom);
        yield return ("*", "*", top, "*", "*");
        yield return ("*", "*", "*", right, bottom);
        yield return ("*", "*", "*", right, "*");
        yield return ("*", "*", "*", "*", bottom);
        yield return ("*", "*", "*", "*", "*");
    }
}
