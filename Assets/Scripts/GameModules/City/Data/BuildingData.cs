using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingData : ScriptableObject, IPrefabReference
{
    public string Name;
    public Vector2Int EntranceOffset;
    public Vector2Int Dimensions;
    public GameObject ViewPrefab;

    GameObject IPrefabReference.Prefab => ViewPrefab;
    string IPrefabReference.Name => Name;
}
