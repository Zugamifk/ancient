using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapInputHandler : MonoBehaviour, IMouseInputHandler
{
    [SerializeField]
    Map _map;

    MouseInputState IMouseInputHandler.GetInputState(MouseInputState state)
    {
        var context = new MapInputContext()
        {
            Map = _map,
            CheatAction = CheatAction
        };
        return new MapMouseInput(state, context);
    }

    void CheatAction(Vector3 position)
    {
        _map.SetTile(position, Name.Tile.Road);
    }
}
