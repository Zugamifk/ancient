using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapMouseInput : MouseInputState
{
    Map _map;
    public MapMouseInput(MouseInputState state, Map map)
        : base(state)
    {
        _map = map;
    }

    public override MouseInputState MouseUp()
    {
        UpdateTile();
        return new IdleMouseInputState(this);
    }

    public override MouseInputState Drag()
    {
        UpdateTile();
        return this;
    }

    void UpdateTile()
    {
        var pos = _context.CameraController.GetMouseWorldPosition();
        _map.SetTile(pos, Names.Tiles.Road);
    }
}
