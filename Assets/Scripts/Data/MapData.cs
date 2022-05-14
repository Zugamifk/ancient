using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapData : ScriptableObject
{
    public Vector2Int Dimensions;
    public string DefaultTile;

    private void OnEnable()
    {
        DataService.Register(this);
    }
}
