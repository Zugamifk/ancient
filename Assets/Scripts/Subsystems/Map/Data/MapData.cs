using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Map.Data
{
    public class MapData : ScriptableObject
    {
        public Vector2Int Dimensions;
        public string DefaultTile;
    }
}