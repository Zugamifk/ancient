using City.ViewModel;
using Map.View;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace City.View
{
    public class BuildingViewSpawner : MapViewSpawner<IBuildingModel, Building>
    {
        protected override IIdentifiableLookup<IBuildingModel> GetIdentifiables() => Game.Model.City.Buildings;
    }
}