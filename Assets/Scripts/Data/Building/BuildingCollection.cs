using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingCollection : ScriptableObject, IPrefabLookup
{
    public BuildingData[] Buildings;

    Dictionary<string, BuildingData> _nameToBuilding = new Dictionary<string, BuildingData>();

    public GameObject GetPrefab(string name) => _nameToBuilding[name].ViewPrefab;
    public BuildingData this[string name] => _nameToBuilding[name];

    private void OnEnable()
    {
        foreach (var b in Buildings)
        {
            if (b != null)
            {
                _nameToBuilding.Add(b.Name, b);
            } else
            {
                throw new System.InvalidOperationException("Null in BuildingCollection!");
            }
        }
        Prefabs.Register<IBuildingModel>(this);
    }
}
