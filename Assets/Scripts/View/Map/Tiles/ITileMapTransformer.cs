using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITileMapTransformer 
{
    Vector3Int GetTileFromPosition(Vector3 position);

    Vector3 GetWorldCenterOftile(Vector3Int position);

    Vector3 ModelToWorld(Vector3 local);
}
