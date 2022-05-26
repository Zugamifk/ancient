using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePrefabLookup<TKeyHolder, TReference> : ScriptableObject, IPrefabLookup
    where TKeyHolder : IKeyHolder
    where TReference : IPrefabReference
{
    public TReference[] PrefabReferences;

    Dictionary<string, TReference> _nameToPrefab = new Dictionary<string, TReference>();

    public GameObject GetPrefab(string name) => _nameToPrefab[name].Prefab;
    public TReference this[string name] => _nameToPrefab[name];

    private void OnEnable()
    {
        foreach (var p in PrefabReferences)
        {
            if (p != null)
            {
                _nameToPrefab.Add(p.Name, p);
            }
            else
            {
                throw new System.InvalidOperationException("Null in BuildingCollection!");
            }
        }
        Prefabs.Register<TKeyHolder>(this);
    }
}
