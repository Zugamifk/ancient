using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class ViewSpawner<TIdentifiable, TView> : IModelUpdateable
    where TIdentifiable : IIdentifiable
    where TView : MonoBehaviour
{
    protected Dictionary<string, TView> _spawnedViews = new Dictionary<string, TView>();
    protected IPrefabLookup _prefabLookup;
    protected Transform _viewParent;

    public ViewSpawner(IPrefabLookup prefabLookup, Transform viewParent)
    {
        _prefabLookup = prefabLookup;
        _viewParent = viewParent;
        UpdateableGameObjectRegistry.RegisterUpdateable(this);
    }

    public TView GetView(string id) => _spawnedViews[id];

    void IModelUpdateable.UpdateFromModel(IGameModel model)
    {
        var modelIdentifiables = GetIdentifiables(model);

        List<string> toRemove = new List<string>();
        foreach (var id in _spawnedViews.Keys)
        {
            if (!modelIdentifiables.HasKey(id))
            {
                GameObject.Destroy(_spawnedViews[id].gameObject);
                toRemove.Add(id);
            }
        }

        foreach (var id in toRemove)
        {
            _spawnedViews.Remove(id);
        }

        foreach (var id in modelIdentifiables.AllItems)
        {
            if (!_spawnedViews.ContainsKey(id.Id))
            {
                var key = GetPrefabKey(id);
                var prefab = _prefabLookup.GetPrefab(key);
                var instance = GameObject.Instantiate(prefab);
                if(_viewParent!=null)
                {
                    instance.transform.SetParent(_viewParent);
                    SetLayer(instance.transform, _viewParent.gameObject.layer);
                }
                var view = instance.GetComponent<TView>();
                _spawnedViews.Add(id.Id, view);
                SpawnedView(id, view);
            }
        }
    }

    protected abstract IIdentifiableLookup<TIdentifiable> GetIdentifiables(IGameModel model);
    protected virtual void SpawnedView(TIdentifiable model, TView view) { }
    protected virtual string GetPrefabKey(TIdentifiable model)
    {
        return model.Id;
    }

    private void SetLayer(Transform tf, int layer)
    {
        tf.gameObject.layer = layer;
        foreach (Transform child in tf)
        {
            SetLayer(child, layer);
        }
    }
}
