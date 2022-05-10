using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretDefenseModel : ITurretDefenseViewModel
{
    public Vector2Int SpawnPosition;
    public Vector2Int EndPoint;
    public int Lives;
    public int MaxLives;
    public TimeSpan StartTime;
    public TimeSpan CurrentTime;
    public int SpawnedCount;
    public int CurrentWave = -1;
    public List<CharacterModel> Enemies = new List<CharacterModel>();
    public string BuildingBeingPlaced;
    public IdentifiableCollection<TurretModel> Turrets;
    public event Action<TurretDefenseModel, Vector2Int> PlaceBuilding;
    public event Action<TurretDefenseModel, string> StartPlacingBuilding;
    public event Action<TurretDefenseModel> StopPlacingBuilding;

    #region ITurretDefenseViewModel
    int ITurretDefenseViewModel.Lives => Lives;

    int ITurretDefenseViewModel.MaxLives => MaxLives;

    int ITurretDefenseViewModel.CurrentWave => CurrentWave;

    int ITurretDefenseViewModel.TotalWaves => 0;

    TimeSpan ITurretDefenseViewModel.CurrentTime => CurrentTime;

    string ITurretDefenseViewModel.BuildingBeingPlaced => BuildingBeingPlaced;

    IIdentifiableLookup<ITurretModel> ITurretDefenseViewModel.Turrets => Turrets;

    void ITurretDefenseViewModel.OnPlaceBuilding(Vector2Int position)
    {
        PlaceBuilding?.Invoke(this, position);
    }

    void ITurretDefenseViewModel.OnStartPlacingBuilding(string name)
    {
        StartPlacingBuilding?.Invoke(this, name);
    }

    void ITurretDefenseViewModel.OnStopPlacingBuilding()
    {
        StopPlacingBuilding?.Invoke(this);
    }
    #endregion
}
