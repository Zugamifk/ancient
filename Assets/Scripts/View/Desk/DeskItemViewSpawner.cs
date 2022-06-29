using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeskItemViewSpawner : RegisteredPrefabViewSpawner<IItemModel, DeskItem>
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

    protected override void SpawnedView(IItemModel model, DeskItem view)
    {
        var spawn = _spawnNameToTransformLookup[model.DeskSpawnLocation];
        spawn.PositionItem(view);
    }

    protected override IItemModel GetModel(Guid model)
    {
        return Game.Model.Inventory.Items.GetItem(model);
    }

    protected override IEnumerable<IItemModel> AllModels()
    {
        return Game.Model.Inventory.Items.AllItems;
    }
}
