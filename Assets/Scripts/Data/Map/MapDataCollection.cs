using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapDataCollection : ScriptableObject
{
    [SerializeField]
    MapData[] _mapData;

    Dictionary<string, MapData> _nameToMapData = new Dictionary<string, MapData>();

    public MapData GetData(string name)
    {
        return _nameToMapData[name];
    }

    private void OnEnable()
    {
        foreach (var m in _mapData)
        {
            _nameToMapData[m.Key] = m;
        }
    }
}
