using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Tiles
{
    // ground
    public static string Grass => TileSprites.ETileEdge.Grass.ToString();
    public static string Road => TileSprites.ETileEdge.Road.ToString();

    public static class Buildings
    {
        public const string Base = "Base";
        public const string Mystery = "Mystery";
        public const string Tower = "Tower";
    }
}
