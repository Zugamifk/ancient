using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGridModel : IMapGridModel
{
    public Guid Id { get; set; }
    public Vector2Int Dimenions;
    public Dictionary<Vector2Int, MapTileModel> Map = new Dictionary<Vector2Int, MapTileModel>();


    #region IMapGridModel
    Vector2Int IMapGridModel.Dimensions => Dimenions;
    IMapTileModel IMapGridModel.GetTile(Vector2Int position) => Map[position];

    bool IMapGridModel.InBounds(Vector2Int pos) => Map.ContainsKey(pos);

    #endregion
}
