using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMapMouseInputHandler
{
    void SetTileMapTransformer(ITileMapTransformer transformer);
    bool ShouldHandleInput(Vector3 position);
    void HandleInput(Vector3 position);
}
