using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapMouseInput : MouseInputState
{
    Tilemap _tilemap;
    public MapMouseInput(Tilemap tilemap)
    {
        _tilemap = tilemap;
    }

    public override MouseInputState MouseUp()
    {
        UpdateTile();
        return new IdleMouseInputState();
    }

    public override MouseInputState Drag()
    {
        UpdateTile();
        return this;
    }

    void UpdateTile()
    {
        var pos = Services.Find<CameraController>().GetMouseWorldPosition();
        var cell = _tilemap.WorldToCell(pos);
        Services.Find<TileMapper>().SetTile(cell.x, cell.y, Tiles.Road);
    }
}
