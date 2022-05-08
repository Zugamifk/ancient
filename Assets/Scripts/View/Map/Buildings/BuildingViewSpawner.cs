using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingViewSpawner : ViewSpawner<IBuildingModel, Building>
{
    TileMapper _tileMapper;

    public BuildingViewSpawner(IPrefabLookup prefabLookup, Transform viewParent, TileMapper tileMapper)
        : base(prefabLookup, viewParent)
    {
        _tileMapper = tileMapper;
    }

    protected override IIdentifiableLookup<IBuildingModel> GetIdentifiables(IGameModel model) => model.Map.Buildings;

    protected override void SpawnedView(IBuildingModel model, Building view)
    {
        view.transform.position = _tileMapper.GetWorldCenterOftile((Vector3Int)model.Position);
    }

    protected override string GetPrefabKey(IBuildingModel model) => model.Name;
}
