using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Map.ViewModel
{
    public interface IGridModel : IIdentifiable
    {
        Vector2Int Dimensions { get; }
        ITileModel GetTile(Vector2Int pos);
        bool InBounds(Vector2Int pos);
    }
}