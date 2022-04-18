using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingCollection : ScriptableObject, IPrefabCollection
{
    public BuildingData[] Buildings;

    Dictionary<string, BuildingData> _nameToBuilding = new Dictionary<string, BuildingData>();

    public GameObject GetPrefab(string name) => _nameToBuilding[name].ViewPrefab;

    private void OnEnable()
    {
        foreach (var b in Buildings)
        {
            if (b != null)
            {
                _nameToBuilding.Add(b.name, b);
            } else
            {
                throw new System.InvalidOperationException("Null in BuildingCollection!");
            }
        }
    }
}
