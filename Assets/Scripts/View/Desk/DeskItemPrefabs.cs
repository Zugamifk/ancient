using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeskItemPrefabs : ScriptableObject
{
    [SerializeField]
    DeskItem[] _prefabs;

    Dictionary<string, DeskItem> _nameToDeskItem = new Dictionary<string, DeskItem>();

    private void OnEnable()
    {
        foreach(var p in _prefabs)
        {
            _nameToDeskItem[p.Name] = p;
        }
    }

    public DeskItem GetDeskItem(string name) => _nameToDeskItem[name];
}
