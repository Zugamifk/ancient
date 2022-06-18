using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TowerDefense.ViewModel;
using Map.View;
using System;

namespace TowerDefense.Views
{
    public class TowerViewSpawner : MapViewSpawner<ITower, Tower>
    {

        protected override IEnumerable<ITower> AllModels() => Game.Model.GetModel<ITowerDefense>().Towers.AllItems;

        protected override ITower GetModel(Guid id) => Game.Model.GetModel<ITowerDefense>().Towers.GetItem(id);
    }
}