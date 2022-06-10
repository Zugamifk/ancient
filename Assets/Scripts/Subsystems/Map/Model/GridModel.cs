using Map.ViewModel;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Map.Model
{
    public class GridModel : IGridModel
    {
        public Guid Id { get; set; }
        public Vector2Int Dimenions;
        public Dictionary<Vector2Int, MapTileModel> Map = new Dictionary<Vector2Int, MapTileModel>();


        #region IMapGridModel
        Vector2Int IGridModel.Dimensions => Dimenions;
        ITileModel IGridModel.GetTile(Vector2Int position) => Map[position];

        bool IGridModel.InBounds(Vector2Int pos) => Map.ContainsKey(pos);

        #endregion
    }
}