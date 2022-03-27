using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapMouseInput : MouseInputState
{
    Map _map;
    public MapMouseInput(Map map, CameraController cameraController)
        : base(cameraController)
    {
        _map = map;
    }

    public override MouseInputState MouseUp()
    {
        UpdateTile();
        return new IdleMouseInputState(_context);
    }

    public override MouseInputState Drag()
    {
        UpdateTile();
        return this;
    }

    void UpdateTile()
    {
        var pos = _context.CameraController.GetMouseWorldPosition();
        _map.SetTile(pos, Tiles.Road);
    }
}
