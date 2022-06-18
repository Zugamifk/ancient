using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpiritVessel.ViewModel;
using System.Linq;

namespace SpiritVessel.View
{
    public class SpiritVesselCharacterViewSpawner : MapViewCharacterSpawner
    {
        protected override IEnumerable<Guid> GetCharacterIds()
            => Game.Model.GetModel<ISpiritVesselModel>().Map.CharacterIds;
    }
}
