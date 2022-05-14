using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapInputHandler : MonoBehaviour, IMouseInputHandler
{
    [SerializeField]
    Map _map;

    MapInputContext _inputContext;

    void Awake()
    {
        _inputContext = new MapInputContext()
        {
            Map = _map,
        };
    }

    MouseInputState IMouseInputHandler.GetInputState(MouseInputState state)
    {
        return new MapMouseInput(state, _inputContext);
    }

    void CheatAction(Vector3 position)
    {
        _map.SetTile(position, Name.Tile.Road);
    }
}
