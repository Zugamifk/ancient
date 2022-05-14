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
        Prefabs.Register<IItemModel>(this);
    }

    public DeskItem GetDeskItem(string name) => _nameToDeskItem[name];

    public GameObject GetPrefab(string id) => GetDeskItem(id).gameObject;
}
