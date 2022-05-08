using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeskItemPrefabs : ScriptableObject, IPrefabLookup
{
    [SerializeField]
    DeskItem[] _prefabs;

    Dictionary<string, DeskItem> _nameToDeskItem = new Dictionary<string, DeskItem>();

    private void OnEnable()
    {
        foreach (var p in _prefabs)
        {
            if (p != null)
            {
                _nameToDeskItem[p.Name] = p;
            }
        }
    }

    public DeskItem GetDeskItem(string name) => _nameToDeskItem[name];

    GameObject IPrefabLookup.GetPrefab(string id) => GetDeskItem(id).gameObject;
}
