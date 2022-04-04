using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Names
{
    public static class Tiles
    {
        // ground
        public static string Grass => TileSprites.ETileEdge.Grass.ToString();
        public static string Road => TileSprites.ETileEdge.Road.ToString();
    }

    public static class Buildings
    {
        public const string Manor = "Manor";
        public const string House = "House";
        public const string Tower = "Tower";
    }

    public const string TestAgent = "TestAgent";
}
