using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMapper : MonoBehaviour, ITileMapTransformer
{

    [SerializeField]
    Tilemap _tilemap;

    public Guid MapId { get; set; }
    Guid _gridStateId;
    readonly string _defaultTileType = Name.Tile.Grass;

    void Update()
    {
        var map = Game.Model.Maps[MapId];
        if (map != null && map.Grid.StateId != _gridStateId)
        {
            BuildTilemap(map);
            _gridStateId = map.Grid.StateId;
        }
    }

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
        var d = grid.Dimensions;
        var dimensions = new BoundsInt(-d.x / 2, -d.y / 2, 0, d.x, d.y, 1);
        var tiles = new Tile[d.x * d.y];
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
        return _tilemap.CellToLocalInterpolated(position + _tilemap.GetLayoutCellCenter());
    }

    public Vector3 ModelToWorld(Vector3 local)
    {
        return _tilemap.CellToLocalInterpolated(local + _tilemap.GetLayoutCellCenter());
    }

    string GetTileType(IGridModel grid, int x, int y)
    {
        var dimensions = grid.Dimensions;
        var w = dimensions.x / 2;
        var h = dimensions.y / 2;
        if (x < -w || x >= w || y < -h || y >= h)
        {
            return _defaultTileType;
        }
        else
        {
            return grid.GetTile(new Vector2Int(x, y)).Type;
        }
    }

    Tile BuildTile(int x, int y, IGridModel grid)
    {
        var type = GetTileType(grid, x, y);
        var left = GetTileType(grid, x - 1, y);
        var top = GetTileType(grid, x, y + 1);
        var right = GetTileType(grid, x + 1, y);
        var bottom = GetTileType(grid, x, y - 1);
        return DataService.GetData<TileDataCollection>().GetTile(type, left, top, right, bottom);
    }
}
