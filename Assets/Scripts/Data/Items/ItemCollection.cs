using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollection : ScriptableObject
{
    [SerializeField]
    ItemData[] _items;

    Dictionary<string, ItemData> _nameToItemData = new Dictionary<string, ItemData>();

    public ItemData GetData(string name)
    {
        return _nameToItemData[name];
    }

    private void OnEnable()
    {
        foreach (var i in _items)
        {
            _nameToItemData[i.Name] = i;
        }
    }

}
