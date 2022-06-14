using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static partial class Name
{
    public static class Camera
    {
        public static string Desk = "Desk";
        public static string City = "City";
        public static string Examinables = "Examinables";
    }

    public static class Tile
    {
        // ground
        public static string Grass => "Grass";
        public static string Road => "Road";
        public static string Building => "Building";
    }

    public static class Building
    {
        public const string Manor = "Manor";
        public const string House = "House";
        public const string Tower = "Tower";
    }

    public const string TestAgent = "Test";
}
