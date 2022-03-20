using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileCollection
{
    Dictionary<(int, int, int, int), TileData> _edgeTypeToTileData = new Dictionary<(int, int, int, int), TileData>();

    public TileData this[ETileEdge left, ETileEdge right, ETileEdge top, ETileEdge bottom] => 
        _edgeTypeToTileData[((int)left, (int)right, (int)top, (int)bottom)];

    public TileCollection(TileSprites sprites)
    {
        foreach(var td in sprites.GroundTiles)
        {
            var key = ((int)td.left, (int)td.right, (int)td.top, (int)td.bottom);
            TileData tileData;
            if(!_edgeTypeToTileData.TryGetValue(key, out tileData))
            {
                tileData = new TileData()
                {
                    Left = td.left,
                    Right = td.right,
                    Top = td.top,
                    Bottom = td.bottom
                };
                _edgeTypeToTileData.Add(key, tileData);
            }

            var tile = ScriptableObject.CreateInstance<Tile>();
            tile.sprite = td.sprite;
            tileData.Tiles.Add(tile);
        }
    }
}
