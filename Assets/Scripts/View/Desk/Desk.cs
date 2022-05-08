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

    ViewSpawner<IItemModel, DeskItem> _itemSpawner = new ViewSpawner<IItemModel, DeskItem>();
    Dictionary<string, DeskItem> _idToDeskItem = new Dictionary<string, DeskItem>();
    Dictionary<string, DeskItemSpawn> _spawnNameToSpawn = new Dictionary<string, DeskItemSpawn>();
    Dictionary<string, Book> _openBookNameToBook = new Dictionary<string, Book>();

    void Awake()
    {
        foreach (var s in _spawns)
        {
            _spawnNameToSpawn[s.SpawnName] = s;
        }

        foreach (var b in _books)
        {
            _openBookNameToBook[b.Name] = b;
        }

        UpdateableGameObjectRegistry.RegisterUpdateable(this);
    }

    public void UpdateFromModel(IGameModel model)
    {
        _itemSpawner.UpdateSpawns(
            model.Inventory.Items,
            _idToDeskItem,
            i => _prefabs.GetDeskItem(i.Name),
            transform,
            OnSpawnDeskItem
        );
    }

    void OnSpawnDeskItem(IItemModel model, DeskItem item)
    {
        var spawn = _spawnNameToSpawn[model.DeskSpawnLocation];
        spawn.PositionItem(item);

        var clickable = item.GetComponentInChildren<Clickable>();
        if (clickable != null)
        {
            clickable.Clicked += model.ClickItem;
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
