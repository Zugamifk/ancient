using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeskItemViewSpawner : ViewSpawner<IItemModel, DeskItem>
{
    [SerializeField]
    DeskItemSpawn[] _spawns;

    Dictionary<string, DeskItemSpawn> _spawnNameToTransformLookup = new();
    void Awake()
    {
        foreach (var s in _spawns)
        {
            _spawnNameToTransformLookup[s.SpawnName] = s;
        }
    }

    protected override IIdentifiableLookup<IItemModel> GetIdentifiables() => Game.Model.Inventory.Items;

    protected override void SpawnedView(IItemModel model, DeskItem view)
    {
        var spawn = _spawnNameToTransformLookup[model.DeskSpawnLocation];
        spawn.PositionItem(view);

        var clickable = view.GetComponentInChildren<Clickable>();
        if (clickable != null)
        {
            clickable.Clicked += model.ClickItem;
        }
    }
}
