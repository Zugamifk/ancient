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
    [SerializeField]
    Book[] _books;

    Dictionary<string, DeskItem> _itemNameToDeskItem = new Dictionary<string, DeskItem>();
    Dictionary<string, DeskItemSpawn> _spawnNameToSpawn = new Dictionary<string, DeskItemSpawn>();
    HashSet<IModelUpdateable> _spawnedUpdateables = new HashSet<IModelUpdateable>();
    Dictionary<string, Book> _openBookNameToBook = new Dictionary<string, Book>();

    void Awake()
    {
        foreach(var s in _spawns)
        {
            _spawnNameToSpawn[s.SpawnName] = s;
        }

        foreach(var b in _books)
        {
            _openBookNameToBook[b.Name] = b;
            RegisterUpdateables(b.gameObject);
        }
    }

    public void UpdateFromModel(IGameModel model)
    {
        DestroyRemovedItems(model.Inventory.Items);
        SpawnMissingItems(model.Inventory.Items);

        _spawnedUpdateables.RemoveWhere(u => u == null);
        foreach(var updateable in _spawnedUpdateables)
        {
            updateable.UpdateFromModel(model);
        }
    }

    void DestroyRemovedItems(IEnumerable<IItemModel> existingItems)
    {
        List<string> toRemove = new List<string>();
        foreach (var kv in _itemNameToDeskItem)
        {
            if (!existingItems.Any(item => item.Name == kv.Key))
            {
                Destroy(kv.Value.gameObject);
                toRemove.Add(kv.Key);
            }
        }
        foreach (var item in toRemove)
        {
            _itemNameToDeskItem.Remove(item);
        }
    }

    void SpawnMissingItems(IEnumerable<IItemModel> existingItems)
    {
        foreach (var item in existingItems)
        {
            DeskItem deskItem;
            if (!_itemNameToDeskItem.TryGetValue(item.Name, out deskItem))
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

        _itemNameToDeskItem.Add(model.Name, item);
        var clickable = item.GetComponentInChildren<Clickable>();
        if (clickable != null)
        {
            clickable.Clicked += (_, button) => model.ClickItem(button);
        }

        RegisterUpdateables(item.gameObject);
    }

    void RegisterUpdateables(GameObject go)
    {
        foreach (var u in go.GetComponentsInChildren<IModelUpdateable>())
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
