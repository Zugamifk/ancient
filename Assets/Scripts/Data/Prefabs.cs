using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Prefabs
{
    static Dictionary<Type, IPrefabLookup> _nameableTypeToPrefabCollection = new Dictionary<Type, IPrefabLookup>();

    public static void Register<TKeyHolder>(IPrefabLookup lookup)
        where TKeyHolder : IKeyHolder
    {
        _nameableTypeToPrefabCollection[typeof(TKeyHolder)] = lookup;
    }

    public static GameObject GetInstance<TKeyHolder>(TKeyHolder key)
        where TKeyHolder : IKeyHolder
    {
        var data = _nameableTypeToPrefabCollection[typeof(TKeyHolder)];
        var prefab = data.GetPrefab(key.Key);
        return GameObject.Instantiate(prefab);
    }
}
