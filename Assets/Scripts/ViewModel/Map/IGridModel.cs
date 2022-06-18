using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGridModel
{
    Guid StateId { get; }
    Vector2Int Dimensions { get; }
    ITileModel GetTile(Vector2Int pos);
    bool InBounds(Vector2Int pos);
}