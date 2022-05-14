using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingViewSpawner : ViewSpawner<IBuildingModel, Building>
{

    public BuildingViewSpawner(IPrefabLookup prefabLookup, Transform viewParent)
        : base(prefabLookup, viewParent)
    {
    }

    protected override IIdentifiableLookup<IBuildingModel> GetIdentifiables() => Game.Model.Map.Buildings;

    protected override string GetPrefabKey(IBuildingModel model) => model.Name;
}
