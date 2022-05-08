using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeskItemViewSpawner : ViewSpawner<IItemModel, DeskItem>
{
    Dictionary<string, DeskItemSpawn> _spawnNameToTransformLookup;
    public DeskItemViewSpawner(DeskItemPrefabs prefabs, Transform viewParent, Dictionary<string, DeskItemSpawn> spawnLocationLookup)
        : base(prefabs, viewParent)
    {
        _spawnNameToTransformLookup = spawnLocationLookup;
    }

    protected override IIdentifiableLookup<IItemModel> GetIdentifiables(IGameModel model)
    {
        return model.Inventory.Items;
    }

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
