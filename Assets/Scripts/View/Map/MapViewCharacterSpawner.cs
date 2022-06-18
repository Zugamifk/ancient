using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class MapViewCharacterSpawner : MapViewSpawner<ICharacterModel, Character>
{
    protected sealed override IEnumerable<ICharacterModel> AllModels()
    {
        return GetCharacterIds().Select(Game.Model.Characters.GetItem);
    }

    protected sealed override ICharacterModel GetModel(Guid model)
    {
        return Game.Model.Characters.GetItem(model);
    }

    protected abstract IEnumerable<Guid> GetCharacterIds();
}
