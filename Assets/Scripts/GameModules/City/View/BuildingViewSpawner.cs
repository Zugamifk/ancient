using City.ViewModel;
using Map.View;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace City.View
{
    public class BuildingViewSpawner : MapViewSpawner<IBuildingModel, Building>
    {
        protected override IEnumerable<IBuildingModel> AllModels()
            => Game.Model.GetModel<ICityModel>().Buildings.AllItems;

        protected override IBuildingModel GetModel(Guid model)
            => Game.Model.GetModel<ICityModel>().Buildings.GetItem(model);
    }
}