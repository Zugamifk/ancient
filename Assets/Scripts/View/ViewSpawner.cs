using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ViewSpawner<TIdentifiable, TSpawnable>
    where TIdentifiable : IIdentifiable
    where TSpawnable : MonoBehaviour
{
    public void UpdateSpawns(IEnumerable<TIdentifiable> models, Dictionary<string, TSpawnable> spawned, Func<TIdentifiable, TSpawnable> spawnablePrefabGetter, Transform spawnableParent, Action<TIdentifiable, TSpawnable> onSpawned = null)
    {
        List<string> toRemove = new List<string>();
        foreach(var kv in spawned)
        {
            if(!models.Any(m=>m.Id == kv.Key))
            {
                GameObject.Destroy(kv.Value.gameObject);
                toRemove.Add(kv.Key);
            }
        }

        foreach(var id in toRemove)
        {
            spawned.Remove(id);
        }
        
        foreach(var m in models)
        {
            if(!spawned.ContainsKey(m.Id))
            {
                var prefab = spawnablePrefabGetter.Invoke(m);
                var instance = GameObject.Instantiate(prefab);
                instance.transform.SetParent(spawnableParent);
                SetLayer(instance.transform, spawnableParent.gameObject.layer);
                spawned.Add(m.Id, instance);
                onSpawned?.Invoke(m, instance);
            }
        }
    }

    void SetLayer(Transform tf, int layer)
    {
        tf.gameObject.layer = layer;
        foreach (Transform child in tf)
        {
            SetLayer(child, layer);
        }
    }
}
