using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapInputContext
{
    public Map Map;
    public string BuildingBeingPlaced;
    public Action<Vector2Int> PlaceBuilding;
    public Action StopPlacing;
    public Action<Vector3> DoCheat;
}
