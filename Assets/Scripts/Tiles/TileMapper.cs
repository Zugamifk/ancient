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
    Vector2Int _dimensions;

    TileCollection _tileCollection;

    private void Awake()
    {
        _tileCollection = new TileCollection(_tileSprites);
    }

    private void Start()
    {
        var tiles = new Tile[_dimensions.x * _dimensions.y];
        int i = 0;
        var tileData = _tileCollection["Grass", "Grass", "Grass", "Grass", "Grass"];
        for (int x = 0; x < _dimensions.x; x++)
        {
            for (int y = 0; y < _dimensions.x; y++)
            {
                tiles[i++] = tileData.GetRandomTile();
            }
        }
        _tilemap.SetTilesBlock(new BoundsInt(-_dimensions.x/2, -_dimensions.y/2, 0, _dimensions.x, _dimensions.y, 1), tiles);
    }

}
