using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapInputHandler : MonoBehaviour, IMouseInputHandler
{
    [SerializeField]
    TileMapper _tileMapper;

    MouseInputState IMouseInputHandler.GetInputState(MouseInputState state)
    {
        return new MapMouseInput(state, _tileMapper);
    }
}
