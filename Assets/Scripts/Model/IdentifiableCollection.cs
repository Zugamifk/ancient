using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdentifiableCollection<TModel>
    where TModel : IIdentifiable
{
    Dictionary<string, TModel> _identifiables = new Dictionary<string, TModel>();
    Dictionary<string, string> _uniqueIdentifiableNameToId = new Dictionary<string, string>();

    public IEnumerable<TModel> AllItems => _identifiables.Values;

    public TModel this[string key] => GetItem(key);

    public void AddItem(TModel model, string uniqueName = null)
    {
        if (!string.IsNullOrEmpty(uniqueName))
        {
            _uniqueIdentifiableNameToId[uniqueName] = model.Id;
        }

        _identifiables[model.Id] = model;
    }

    public void RemoveItem(string key)
    {
        if (!_identifiables.ContainsKey(key))
        {
            var uid = _uniqueIdentifiableNameToId[key];
            _uniqueIdentifiableNameToId.Remove(key);
            key = uid;
        }

        _identifiables.Remove(key);
    }

    public TModel GetItem(string key)
    {
        if (!_identifiables.ContainsKey(key))
        {
            key = _uniqueIdentifiableNameToId[key];
        }

        return _identifiables[key];
    }

}
