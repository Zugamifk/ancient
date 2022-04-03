using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMapper : MonoBehaviour
{
    [SerializeField]
    TileSprites _tileSprites;
    [SerializeField]
    Tilemap _tilemap;
    [SerializeField]
    BoundsInt _dimensions;

    TileCollection _tileCollection;

    TileData _default;
    Dictionary<(int, int), TileData> _tiles = new Dictionary<(int, int), TileData>();

    public void SetTile(Vector3 position, string type)
    {
        var cell = _tilemap.WorldToCell(position);
        int x = cell.x, y = cell.y;
        SetTile(x, y, type);
    }

    public void CreateRoad(Vector3 start, Vector3 end)
    {
        var pointA = _tilemap.WorldToCell(start);
        var pointB = _tilemap.WorldToCell(end);
        int xs = Math.Sign(pointB.x - pointA.x);
        int ys = Math.Sign(pointB.y - pointA.y);
        for (int x = pointA.x; x != pointB.x; x += xs)
        {
            SetTile(x, pointA.y, Names.Tiles.Road);
        }

        for (int y = pointA.y; y != pointB.y + ys; y += ys)
        {
            SetTile(pointB.x, y, Names.Tiles.Road);
        }
    }

    private void Awake()
    {
        _tileCollection = new TileCollection(_tileSprites);
    }

    private void Start()
    {
        InitializeTiles();
    }

    void InitializeTiles()
    {
        _default = _tileCollection.GetTileData(Names.Tiles.Grass, Names.Tiles.Grass, Names.Tiles.Grass, Names.Tiles.Grass, Names.Tiles.Grass);
        FillWithDefaultTile();
        BuildTilemap();
    }

    void FillWithDefaultTile()
    {
        for (int x = _dimensions.xMin; x < _dimensions.xMax; x++)
        {
            for (int y = _dimensions.yMin; y < _dimensions.yMax; y++)
            {
                _tiles[(x, y)] = _default;
            }
        }
    }

    void BuildTilemap()
    {
        var tiles = new Tile[_dimensions.size.x * _dimensions.size.y];
        int i = 0;
        for (int x = _dimensions.xMin; x < _dimensions.xMax; x++)
        {
            for (int y = _dimensions.yMin; y < _dimensions.yMax; y++)
            {
                var tileData = _tiles[(x, y)];
                tiles[i++] = tileData.GetRandomTile();
            }
        }
        _tilemap.SetTilesBlock(_dimensions, tiles);
    }

    TileData GetTile(int x, int y)
    {
        TileData tileData;
        if (!_tiles.TryGetValue((x, y), out tileData))
        {
            tileData = _default;
        }
        return tileData;
    }

    void SetTile(int x, int y, string type)
    {
        var key = (type, GetTile(x - 1, y).Type, GetTile(x + 1, y).Type, GetTile(x, y + 1).Type, GetTile(x, y - 1).Type);
        var tile = _tileCollection.GetTileData(key);
        if (tile == null)
        {
            throw new System.InvalidOperationException("No TileData for key " + key);
        }

        if (tile == _tiles[(x, y)]) return;

        _tiles[(x, y)] = tile;
        _tilemap.SetTile(new Vector3Int(x, y, 0), tile.GetRandomTile());

        UpdateTile(x - 1, y);
        UpdateTile(x + 1, y);
        UpdateTile(x, y - 1);
        UpdateTile(x, y + 1);
    }

    void UpdateTile(int x, int y)
    {
        var tile = _tiles[(x, y)];
        var newTile = _tileCollection.GetTileData(tile.Type, GetTile(x - 1, y).Type, GetTile(x + 1, y).Type, GetTile(x, y + 1).Type, GetTile(x, y - 1).Type);
        if (newTile != null && newTile != tile)
        {
            _tiles[(x, y)] = newTile;
            _tilemap.SetTile(new Vector3Int(x, y, 0), newTile.GetRandomTile());
        }
    }
}
