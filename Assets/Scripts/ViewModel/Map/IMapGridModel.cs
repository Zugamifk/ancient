using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMapGridModel : IIdentifiable
{
    Vector2Int Dimensions { get; }
    IMapTileModel GetTile(Vector2Int pos);
    bool InBounds(Vector2Int pos);
}
