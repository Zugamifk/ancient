using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Desk : MonoBehaviour, IUpdateable
{
    [SerializeField]
    DeskItemPrefabs _prefabs;
    [SerializeField]
    Transform _inboxSpawn;
    [SerializeField]
    ClockView _clock;
    [SerializeField]
    WorkBook _openedWorkBook;

    Dictionary<string, DeskItem> _spawnedItems = new Dictionary<string, DeskItem>();

    public void UpdateFromModel(IGameModel model)
    {
        DestroyRemovedItems(model.Desk.Items);
        SpawnMissingItems(model.Desk.Items);

        _clock.UpdateClock(model.Time);
        if(_openedWorkBook.IsOpen) {
            _openedWorkBook.UpdateModel(model.WorkBook, model);
        }
    }

    void DestroyRemovedItems(IEnumerable<IInventoryItemModel> existingItems)
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

    void SpawnMissingItems(IEnumerable<IInventoryItemModel> existingItems)
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

    void SpawnDeskItem(IInventoryItemModel model)
    {
        var item = Instantiate(_prefabs.GetDeskItem(model.Name));
        SetSpawnedParent(item.transform);
        _spawnedItems.Add(model.Name, item);
        var clickable = item.GetComponent<Clickable>();
        if (clickable != null)
        {
            clickable.Clicked += (_, button) => model.ClickItem(button);
        }
    }

    void SetSpawnedParent(Transform child)
    {
        child.SetParent(_inboxSpawn);
        SetLayer(child, _inboxSpawn.gameObject.layer);
        child.transform.localPosition = Vector3.zero;
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
