using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretPrefabLookup : IPrefabLookup
{
    Dictionary<string, GameObject> _lookup;
    public TurretPrefabLookup(TurretDefenseData data)
    {
        _lookup = new();
        foreach(var d in data.Turrets)
        {
            _lookup[d.Name] = d.Prefab;
        }
    }

    public GameObject GetPrefab(string key) => _lookup[key];

}
