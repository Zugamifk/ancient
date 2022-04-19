using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Desk : MonoBehaviour, IUpdateable
{
    [SerializeField]
    DeskItemCollection _deskItemCollection;
    [SerializeField]
    Transform _inboxSpawn;
    [SerializeField]
    ClockView _clock;
    [SerializeField]
    WorkBook _workBook;

    Dictionary<string, GameObject> _items = new Dictionary<string, GameObject>();

    public void UpdateModel(IGameModel model)
    {
        List<string> toRemove = new List<string>();
        foreach (var kv in _items)
        {
            if(!model.Desk.Items.Any(item=>item.Name == kv.Key))
            {
                Destroy(kv.Value);
                toRemove.Add(kv.Key);
            }
        }
        foreach(var item in toRemove)
        {
            _items.Remove(item);
        }

        foreach (var item in model.Desk.Items)
        {
            var go = GetItemFromModel(item);
        }

        _clock.UpdateClock(model.Time);
        _workBook.UpdateModel(model.WorkBook, model);
    }

    GameObject GetItemFromModel(IDeskItemModel model)
    {
        GameObject go;
        if (!_items.TryGetValue(model.Name, out go))
        {
            go = SpawnItem(model.Name);
            var clickable = go.GetComponent<Clickable>();
            if (clickable!=null)
            {
                clickable.Clicked += (_, button) => model.ClickItem(button);
            }
        }
        return go;
    }

    GameObject SpawnItem(string name)
    {
        var prefab = Instantiate(_deskItemCollection.GetPrefab(name));
        SetSpawnedParent(prefab.transform);
        _items.Add(name, prefab);
        return prefab;
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
