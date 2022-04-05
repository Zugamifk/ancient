using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSprites : ScriptableObject
{
    public enum ETileEdge
    {
        Grass,
        Road
    }

    [System.Serializable]
    public class TileData
    {
        public Sprite sprite;
        public ETileEdge type;
        public ETileEdge left;
        public ETileEdge right;
        public ETileEdge top;
        public ETileEdge bottom;
    }

    public TileData[] GroundTiles;
}
