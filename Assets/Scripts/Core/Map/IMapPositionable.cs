using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMapPositionable
{
    Guid MapId { get; }
    Vector2 Position { get; }
}
