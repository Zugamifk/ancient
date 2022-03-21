using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
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

    [System.Serializable]
    public class BuildingData
    {
        public string name;
        public int level;
        public Vector2Int dimensions;
        public TileData[] tiles;
    }

    public TileData[] GroundTiles;
    public BuildingData[] Buildings;
}
