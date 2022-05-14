using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class ViewSpawner<TModel, TView> : MonoBehaviour
    where TModel : IIdentifiable, IKeyHolder
    where TView : MonoBehaviour, IView<TModel>
{
    [SerializeField]
    protected Transform _viewParent;
    
    protected Dictionary<Guid, TView> _spawnedViews = new Dictionary<Guid, TView>();

    public TView GetView(Guid id) => _spawnedViews[id];

    void Update()
    {
        var modelIdentifiables = GetIdentifiables();

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
                var instance = Prefabs.GetInstance(m);
                if(_viewParent!=null)
                {
                    instance.transform.SetParent(_viewParent);
                    SetLayer(instance.transform, _viewParent.gameObject.layer);
                }
                var view = instance.GetComponent<TView>();
                if(view == null)
                {
                    throw new InvalidOperationException($"Prefab {instance} doesn't contain a {typeof(TView)}!");
                }

                view.InitializeFromModel(m);
                SpawnedView(m, view);
                _spawnedViews.Add(m.Id, view);
            }
        }
    }

    protected abstract IIdentifiableLookup<TModel> GetIdentifiables();
    protected virtual void SpawnedView(TModel model, TView view) { }
    private void SetLayer(Transform tf, int layer)
    {
        tf.gameObject.layer = layer;
        foreach (Transform child in tf)
        {
            SetLayer(child, layer);
        }
    }
}
