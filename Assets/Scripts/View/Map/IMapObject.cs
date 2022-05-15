using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMapObject
{
    bool UpdatesPosition { get; }
    Vector2 ModelPosition { get; }
    Transform Root { get; }
}
