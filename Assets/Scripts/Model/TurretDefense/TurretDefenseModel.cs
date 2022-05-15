using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretDefenseModel : ITurretDefenseViewModel
{
    public Vector2Int EndPoint;
    public int Lives;
    public int MaxLives;
    public TimeSpan StartTime;
    public TimeSpan CurrentTime;
    public int SpawnedCount {get;set;}
    public int CurrentWave = -1;
    public List<CharacterModel> Enemies = new List<CharacterModel>();
    public string BuildingBeingPlaced;
    public IdentifiableCollection<TurretModel> Turrets = new IdentifiableCollection<TurretModel>();
    public IdentifiableCollection<TurretProjectileModel> Projectiles = new IdentifiableCollection<TurretProjectileModel>();

    #region ITurretDefenseViewModel
    int ITurretDefenseViewModel.Lives => Lives;

    int ITurretDefenseViewModel.MaxLives => MaxLives;

    int ITurretDefenseViewModel.CurrentWave => CurrentWave;

    int ITurretDefenseViewModel.TotalWaves => 0;

    TimeSpan ITurretDefenseViewModel.CurrentTime => CurrentTime;

    string ITurretDefenseViewModel.BuildingBeingPlaced => BuildingBeingPlaced;

    IIdentifiableLookup<ITurretModel> ITurretDefenseViewModel.Turrets => Turrets;

    IIdentifiableLookup<ITurretProjectileModel> ITurretDefenseViewModel.Projectiles => Projectiles;

    IEnumerable<IIdentifiable> ITurretDefenseViewModel.Enemies => Enemies;
    #endregion
}
