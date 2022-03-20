using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class TileSprites : ScriptableObject
{
    [System.Serializable]
    public class TileData
    {
        public Sprite sprite;
        public ETileEdge left;
        public ETileEdge right;
        public ETileEdge top;
        public ETileEdge bottom;
    }

    public TileData[] GroundTiles;
}
