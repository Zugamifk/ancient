using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMapper : MonoBehaviour
{
    [SerializeField]
    Tilemap _tilemap;
    [SerializeField]
    TileDataCollection _tileDataCollection;

    readonly string _defaultTileType = Name.Tile.Grass;

    public void SetTile(int x, int y, IMapModel model)
    {
        var tiles = new Tile[9];
        int t = 0;
        for (int j = y - 1; j <= y + 1; j++)
        {
            for (int i = x - 1; i <= x + 1; i++)
            {
                tiles[t++] = BuildTile(i, j, model.Grid);
            }
        }
        var bounds = new BoundsInt(x - 1, y - 1, 0, 3, 3, 1);
        _tilemap.SetTilesBlock(bounds, tiles);
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
                tiles[i++] = BuildTile(x, y, model.Grid);
            }
        }
        _tilemap.SetTilesBlock(dimensions, tiles);
    }

    public Vector3Int GetTileFromPosition(Vector3 position)
    {
        return _tilemap.WorldToCell(position);
    }

    public Vector3 GetWorldCenterOftile(Vector3Int position)
    {
        return _tilemap.CellToWorld(position);
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

    Tile BuildTile(int x, int y, IMapGridModel grid)
    {
        var type = GetTileType(grid, x, y);
        var left = GetTileType(grid, x - 1, y);
        var top = GetTileType(grid, x, y + 1);
        var right = GetTileType(grid, x + 1, y);
        var bottom = GetTileType(grid, x, y - 1);
        return _tileDataCollection.GetTile(type, left, top, right, bottom);
    }
}
