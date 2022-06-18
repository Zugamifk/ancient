using City.ViewModel;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace City.View
{
    public class CityCharacterViewSpawner : MapViewCharacterSpawner
    {
        protected override IEnumerable<Guid> GetCharacterIds()
            => Game.Model.GetModel<ICityModel>().Map.CharacterIds;
    }
}
