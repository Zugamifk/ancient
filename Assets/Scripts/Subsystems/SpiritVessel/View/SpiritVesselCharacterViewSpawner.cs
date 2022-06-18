using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpiritVessel.ViewModel;
using System.Linq;

namespace SpiritVessel.View
{
    public class SpiritVesselCharacterViewSpawner : MapViewSpawner<ICharacterModel, Character>
    {
        protected override IEnumerable<ICharacterModel> AllModels()
        {
            return Game.Model.GetModel<ISpiritVesselModel>().Map.CharacterIds.Select(Game.Model.Characters.GetItem);
        }

        protected override ICharacterModel GetModel(Guid model)
        {
            return Game.Model.Characters.GetItem(model);
        }
    }
}
