using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Map.View
{
    public class CharacterViewSpawner : MapViewSpawner<ICharacterModel, Character>
    {
        protected override IIdentifiableLookup<ICharacterModel> GetIdentifiables() => Game.Model.Characters;
    }
}