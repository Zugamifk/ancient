using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMapGridModel : IIdentifiable
{
    Vector2Int Dimensions { get; }
    IMapTileModel GetTile(int x, int y);
}
