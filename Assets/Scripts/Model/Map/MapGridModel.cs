using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGridModel : IMapGridModel
{
    public Vector2Int Dimenions;
    public Dictionary<Vector2Int, MapTileModel> Map = new Dictionary<Vector2Int, MapTileModel>();


    #region IMapGridModel
    Vector2Int IMapGridModel.Dimensions => Dimenions;
    IMapTileModel IMapGridModel.GetTile(int x, int y) => Map[new Vector2Int(x, y)];

    #endregion
}
