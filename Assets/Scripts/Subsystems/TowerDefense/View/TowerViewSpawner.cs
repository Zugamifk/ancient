using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TowerDefense.ViewModel;
using Map.View;

namespace TowerDefense.Views
{
    public class TowerViewSpawner : MapViewSpawner<ITower, Tower>
    {
        protected override IIdentifiableLookup<ITower> GetIdentifiables() => Game.Model.GetModel<ITowerDefense>().Towers;
    }
}