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

    protected override IIdentifiableLookup<IItemModel> GetIdentifiables() => Game.Model.Inventory.Items;

    protected override string GetPrefabKey(IItemModel model) => model.Name;

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
