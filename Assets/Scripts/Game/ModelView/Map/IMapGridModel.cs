using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMapGridModel
{
    IMapTileModel GetTile(int x, int y);
}
