using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeskItemCollection : ScriptableObject, IPrefabCollection
{
    [SerializeField]
    DeskItemData[] _items;

    Dictionary<string, DeskItemData> _nameToDeskItemData = new Dictionary<string, DeskItemData>();

    public DeskItemData GetItem(string name)
    {
        return _nameToDeskItemData[name];
    }

    private void OnEnable()
    {
        foreach (var i in _items)
        {
            _nameToDeskItemData[i.Name] = i;
        }
    }

    GameObject IPrefabCollection.GetPrefab(string name)
    {
        return _nameToDeskItemData[name].Prefab;
    }
}
