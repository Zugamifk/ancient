using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PortalDefense.ViewModel
{
    public interface IMapModel : IIdentifiable
    {
        BoundsInt Bounds { get; }
        ITileModel GetTile(Vector2Int position);
    }
}
