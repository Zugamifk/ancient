using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingViewSpawner : MapViewSpawner<IBuildingModel, Building>
{
    protected override IIdentifiableLookup<IBuildingModel> GetIdentifiables() => Game.Model.Map.Buildings;
}

