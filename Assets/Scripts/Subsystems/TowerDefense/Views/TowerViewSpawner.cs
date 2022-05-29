using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TowerDefense.ViewModels;

namespace TowerDefense.Views
{
    public class TowerViewSpawner : MapViewSpawner<ITower, Tower>
    {
        protected override IIdentifiableLookup<ITower> GetIdentifiables() => Game.Model.TowerDefense.Towers;
    }
}