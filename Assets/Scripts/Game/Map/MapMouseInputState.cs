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

    public override MouseInputState UpdateState()
    {
        UpdateTile();
        if (Input.GetMouseButtonUp(0))
        {
            return new IdleMouseInputState(this);
        } else
        {
            return this;
        }
    }

    void UpdateTile()
    {
        var pos = _context.CameraController.GetMouseWorldPosition();
        _map.SetTile(pos, Names.Tiles.Road);
    }
}
