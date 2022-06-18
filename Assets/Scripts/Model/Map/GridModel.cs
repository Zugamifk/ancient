using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridModel : IGridModel
{
    public Guid StateId { get; set; } = new();
    public Vector2Int Dimenions;
    public Dictionary<Vector2Int, MapTileModel> Map = new Dictionary<Vector2Int, MapTileModel>();


    #region IGridModel
    Vector2Int IGridModel.Dimensions => Dimenions;
    ITileModel IGridModel.GetTile(Vector2Int position) => Map[position];

    bool IGridModel.InBounds(Vector2Int pos) => Map.ContainsKey(pos);

    #endregion
}
