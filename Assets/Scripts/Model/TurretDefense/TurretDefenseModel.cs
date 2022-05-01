using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretDefenseModel
{
    public Vector2Int SpawnPosition;
    public Vector2Int EndPoint;
    public int Lives;
    public int SpawnedCount;
    public int CurrentWave;
    public List<CharacterModel> Enemies = new List<CharacterModel>();
}
