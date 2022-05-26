using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MapInputHandler : MonoBehaviour, IMouseInputHandler
{
    [SerializeField]
    TileMapper _tileMapper;
    [SerializeField]
    GameObject[] _mapInputHandlerContainers;

    List<IMapMouseInputHandler> _mapInputHandlers = new();

    void Awake()
    {
        var handlers = _mapInputHandlerContainers.Select(c => c.GetComponent<IMapMouseInputHandler>());
        _mapInputHandlers.AddRange(handlers);
        foreach(var h in handlers)
        {
            h.SetTileMapTransformer(_tileMapper);
        }
    }

    MouseInputState IMouseInputHandler.GetInputState(MouseInputState state)
    {
        return new MapMouseInput(state, _tileMapper, _mapInputHandlers);
    }
}
