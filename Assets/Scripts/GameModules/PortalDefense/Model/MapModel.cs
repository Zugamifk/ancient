using PortalDefense.ViewModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PortalDefense.Model
{
    public class MapModel : IMapModel
    {
        public Dictionary<Vector2Int, TileModel> TileMap = new();

        public ITileModel GetTile(Vector2Int position) => TileMap[position];
    }
}
