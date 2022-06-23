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
        List<Guid> toRemove = new List<Guid>();
        foreach (var id in _spawnedViews.Keys)
        {
            if (GetModel(id) == null)
            {
                DestroyedView(_spawnedViews[id]);
                GameObject.Destroy(_spawnedViews[id].gameObject);
                toRemove.Add(id);
            }
        }

        foreach (var id in toRemove)
        {
            _spawnedViews.Remove(id);
        }

        foreach (var m in AllModels())
        {
            if (!_spawnedViews.ContainsKey(m.Id))
            {
                var instance = Prefabs.GetInstance(m);
                if(_viewParent!=null)
                {
                    instance.transform.SetParent(_viewParent);
                    instance.SetLayerRecursively(_viewParent.gameObject.layer);
                }
                var view = instance.GetComponent<TView>();
                if(view == null)
                {
                    throw new InvalidOperationException($"Prefab {instance} doesn't contain a {typeof(TView)}!");
                }

                SpawnedView(m, view);
                view.InitializeFromModel(m);
                _spawnedViews.Add(m.Id, view);
            }
        }
    }

    protected abstract TModel GetModel(Guid id);
    protected abstract IEnumerable<TModel> AllModels();
    protected virtual void SpawnedView(TModel model, TView view) { }
    protected virtual void DestroyedView(TView view) { }
}
