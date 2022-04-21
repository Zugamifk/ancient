using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingData : ScriptableObject
{
    public string Name;
    public Vector2Int EntranceOffset;
    public Vector2Int Dimensions;
    public GameObject ViewPrefab;
}
