using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGridModel : IMapGridModel
{
    public Dictionary<Vector2Int, MapTileModel> Map = new Dictionary<Vector2Int, MapTileModel>();


    #region IMapGridModel
    IMapTileModel IMapGridModel.GetTile(int x, int y) => Map[new Vector2Int(x, y)];

    #endregion
}
