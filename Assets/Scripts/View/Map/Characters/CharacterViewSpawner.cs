using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterViewSpawner : MapViewSpawner<ICharacterModel, Character>
{
    protected override IIdentifiableLookup<ICharacterModel> GetIdentifiables() => Game.Model.Characters;
}
