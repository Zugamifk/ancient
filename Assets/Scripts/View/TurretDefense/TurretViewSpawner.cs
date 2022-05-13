using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretViewSpawner : ViewSpawner<ITurretModel, Turret>
{
    public TurretViewSpawner(IPrefabLookup prefabLookup, Transform viewParent) : base(prefabLookup, viewParent)
    {
    }

    protected override IIdentifiableLookup<ITurretModel> GetIdentifiables(IGameModel model) => model.TurretDefense.Turrets;

    protected override string GetPrefabKey(ITurretModel model) => model.Name;
}
