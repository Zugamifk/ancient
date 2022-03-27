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

    private void Awake()
    {
        _tileCollection = new TileCollection(_tileSprites);
    }

    private void Start()
    {
        InitializeTiles();
        BuildTilemap();
    }

    void InitializeTiles()
    {
        _default = _tileCollection.GetTileData(Tiles.Grass, Tiles.Grass, Tiles.Grass, Tiles.Grass, Tiles.Grass);
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

        PlaceBuilding(0, 0, Tiles.Buildings.Base);
        PlaceBuilding(5, 2, Tiles.Buildings.Mystery);
        PlaceBuilding(3, -3, Tiles.Buildings.Tower);

        ConnectRoads(new Vector2Int(0, 0), new Vector2Int(5, 5));
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

    public void SetTile(int x, int y, string type)
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

    void PlaceBuilding(int x, int y, string name)
    {
        var bd = _tileCollection.GetBuildingData(name);
        var x0 = bd.Dimensions.x / 2;
        var y0 = bd.Dimensions.y / 2;
        _tilemap.SetTilesBlock(new BoundsInt(x - x0, y - y0, 1, bd.Dimensions.x, bd.Dimensions.y, 1), bd.Tiles);
    }

    void ConnectRoads(Vector2Int pointA, Vector2Int pointB)
    {
        int xs = Math.Sign(pointB.x - pointA.x);
        int ys = Math.Sign(pointB.y - pointA.y);
        for (int x = pointA.x; x != pointB.x; x += xs)
        {
            SetTile(x, pointA.y, Tiles.Road);
        }

        for (int y = pointA.y; y != pointB.y; y += ys)
        {
            SetTile(pointB.x, y, Tiles.Road);
        }
    }
}
