using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMapper : MonoBehaviour
{
    [SerializeField]
    Tilemap _tilemap;

    readonly string _defaultTileType = Names.Tiles.Grass;
    PrefabCollectionSet _prefabCollections;

    public void SetPrefabCollections(PrefabCollectionSet prefabCollections)
    {
        _prefabCollections = prefabCollections;
    }

    public void SetTile(Vector3 position, string type)
    {
        //var cell = _tilemap.WorldToCell(position);
        //int x = cell.x, y = cell.y;
        //SetTile(x, y, type);
    }

    public void BuildTilemap(IMapModel model)
    {
        var grid = model.Grid;
        var dimensions = grid.Dimensions;
        var tiles = new Tile[dimensions.size.x * dimensions.size.y];
        int i = 0;
        for (int y = dimensions.yMin; y < dimensions.yMax; y++)
        {
            for (int x = dimensions.xMin; x < dimensions.xMax; x++)
            {
                var type = GetTileType(grid, x, y);
                var left = GetTileType(grid, x - 1, y);
                var top = GetTileType(grid, x, y + 1);
                var right = GetTileType(grid, x + 1, y);
                var bottom = GetTileType(grid, x, y - 1);
                var tile = _prefabCollections.TileBuilder.GetTile(type, left, top, right, bottom);
                tiles[i++] = tile;
            }
        }
        _tilemap.SetTilesBlock(dimensions, tiles);
    }

    string GetTileType(IMapGridModel grid, int x, int y)
    {
        var dimensions = grid.Dimensions;
        if (x < dimensions.xMin || x >= dimensions.xMax || y < dimensions.yMin || y >= dimensions.yMax)
        {
            return _defaultTileType;
        }
        else
        {
            return grid.GetTile(x, y).Type;
        }
    }

    //void SetTile(int x, int y, string type)
    //{
    //    var tile = _prefabCollections.TileCollection.GetTileData(type, GetTile(x - 1, y).Type, GetTile(x + 1, y).Type, GetTile(x, y + 1).Type, GetTile(x, y - 1).Type);
    //    if (tile == null)
    //    {
    //        throw new InvalidOperationException("No TileData for key " + (type, GetTile(x - 1, y).Type, GetTile(x + 1, y).Type, GetTile(x, y + 1).Type, GetTile(x, y - 1).Type));
    //    }

    //    if (tile == _tiles[(x, y)]) return;

    //    _tiles[(x, y)] = tile;
    //    _tilemap.SetTile(new Vector3Int(x, y, 0), tile.GetRandomTile());

    //    UpdateTile(x - 1, y);
    //    UpdateTile(x + 1, y);
    //    UpdateTile(x, y - 1);
    //    UpdateTile(x, y + 1);
    //}

    //void UpdateTile(int x, int y)
    //{
    //    var tile = _tiles[(x, y)];
    //    var newTile = _prefabCollections.TileCollection.GetTileData(tile.Type, GetTile(x - 1, y).Type, GetTile(x + 1, y).Type, GetTile(x, y + 1).Type, GetTile(x, y - 1).Type);
    //    if (newTile != null && newTile != tile)
    //    {
    //        _tiles[(x, y)] = newTile;
    //        _tilemap.SetTile(new Vector3Int(x, y, 0), newTile.GetRandomTile());
    //    }
    //}
}
