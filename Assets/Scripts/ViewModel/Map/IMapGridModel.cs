using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMapGridModel
{
    BoundsInt Dimensions { get; }
    IMapTileModel GetTile(int x, int y);
}
