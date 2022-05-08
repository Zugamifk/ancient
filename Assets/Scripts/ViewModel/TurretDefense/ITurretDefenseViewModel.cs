using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITurretDefenseViewModel
{
    int Lives { get; }
    int MaxLives { get; }
    int CurrentWave { get; }
    int TotalWaves { get; }
    TimeSpan CurrentTime { get; }
    string BuildingBeingPlaced { get; }
    void OnStartPlacingBuilding(string name);
    void OnStopPlacingBuilding();
    void OnPlaceBuilding(Vector2Int position);
}
