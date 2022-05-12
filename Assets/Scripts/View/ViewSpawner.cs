using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class ViewSpawner<TIdentifiable, TView> : IModelUpdateable
    where TIdentifiable : IIdentifiable
    where TView : MonoBehaviour, IView<TIdentifiable>
{
    protected Dictionary<Guid, TView> _spawnedViews = new Dictionary<Guid, TView>();
    protected IPrefabLookup _prefabLookup;
    protected Transform _viewParent;

    public ViewSpawner(IPrefabLookup prefabLookup, Transform viewParent)
    {
        _prefabLookup = prefabLookup;
        _viewParent = viewParent;
        UpdateableGameObjectRegistry.RegisterUpdateable(this);
    }

    public TView GetView(Guid id) => _spawnedViews[id];

    void IModelUpdateable.UpdateFromModel(IGameModel model)
    {
        var modelIdentifiables = GetIdentifiables(model);

        List<Guid> toRemove = new List<Guid>();
        foreach (var id in _spawnedViews.Keys)
        {
            if (!modelIdentifiables.HasId(id))
            {
                GameObject.Destroy(_spawnedViews[id].gameObject);
                toRemove.Add(id);
            }
        }

        foreach (var id in toRemove)
        {
            _spawnedViews.Remove(id);
        }

        foreach (var m in modelIdentifiables.AllItems)
        {
            if (!_spawnedViews.ContainsKey(m.Id))
            {
                var key = GetPrefabKey(m);
                var prefab = _prefabLookup.GetPrefab(key);
                var instance = GameObject.Instantiate(prefab);
                if(_viewParent!=null)
                {
                    instance.transform.SetParent(_viewParent);
                    SetLayer(instance.transform, _viewParent.gameObject.layer);
                }
                var view = instance.GetComponent<TView>();
                view.InitializeFromModel(model, m);
                SpawnedView(m, view);
                _spawnedViews.Add(m.Id, view);
            }
        }
    }

    protected abstract IIdentifiableLookup<TIdentifiable> GetIdentifiables(IGameModel model);
    protected virtual void SpawnedView(TIdentifiable model, TView view) { }
    protected abstract string GetPrefabKey(TIdentifiable model);

    private void SetLayer(Transform tf, int layer)
    {
        tf.gameObject.layer = layer;
        foreach (Transform child in tf)
        {
            SetLayer(child, layer);
        }
    }
}
