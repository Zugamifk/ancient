using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPositionable : MonoBehaviour
{
    public ITileMapTransformer TileMapTransformer;
    public void UpdatePosition(Vector2 modelPosition)
    {
        transform.position = TileMapTransformer.ModelToWorld(modelPosition);
    }
}
