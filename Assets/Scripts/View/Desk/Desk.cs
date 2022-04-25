using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Desk : MonoBehaviour, IModelUpdateable
{
    [SerializeField]
    DeskItemPrefabs _prefabs;
    [SerializeField]
    DeskItemSpawn[] _spawns;

    Dictionary<string, DeskItem> _spawnedItems = new Dictionary<string, DeskItem>();
    Dictionary<string, DeskItemSpawn> _spawnNameToSpawn = new Dictionary<string, DeskItemSpawn>();
    HashSet<IModelUpdateable> _spawnedUpdateables = new HashSet<IModelUpdateable>();

    void Awake()
    {
        foreach(var s in _spawns)
        {
            _spawnNameToSpawn[s.SpawnName] = s;
        }
    }

    public void UpdateFromModel(IGameModel model)
    {
        DestroyRemovedItems(model.Desk.Items);
        SpawnMissingItems(model.Desk.Items);

        _spawnedUpdateables.RemoveWhere(u => u == null);
        foreach(var updateable in _spawnedUpdateables)
        {
            updateable.UpdateFromModel(model);
        }
    }

    void DestroyRemovedItems(IEnumerable<IItemModel> existingItems)
    {
        List<string> toRemove = new List<string>();
        foreach (var kv in _spawnedItems)
        {
            if (!existingItems.Any(item => item.Name == kv.Key))
            {
                Destroy(kv.Value.gameObject);
                toRemove.Add(kv.Key);
            }
        }
        foreach (var item in toRemove)
        {
            _spawnedItems.Remove(item);
        }
    }

    void SpawnMissingItems(IEnumerable<IItemModel> existingItems)
    {
        foreach (var item in existingItems)
        {
            DeskItem deskItem;
            if (!_spawnedItems.TryGetValue(item.Name, out deskItem))
            {
                SpawnDeskItem(item);
            }
        }
    }

    void SpawnDeskItem(IItemModel model)
    {
        var item = Instantiate(_prefabs.GetDeskItem(model.Name));
        var spawn = _spawnNameToSpawn[model.DeskSpawnLocation];
        spawn.PositionItem(item);

        _spawnedItems.Add(model.Name, item);
        var clickable = item.GetComponent<Clickable>();
        if (clickable != null)
        {
            clickable.Clicked += (_, button) => model.ClickItem(button);
        }

        foreach(var u in item.GetComponentsInChildren<IModelUpdateable>())
        {
            _spawnedUpdateables.Add(u);
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
