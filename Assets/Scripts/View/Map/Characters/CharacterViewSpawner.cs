using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterViewSpawner : MapViewSpawner<ICharacterModel, Character>
{
    protected override IIdentifiableLookup<ICharacterModel> GetIdentifiables() => Game.Model.Characters;

    protected override void SpawnedView(ICharacterModel model, Character view)
    {
        base.SpawnedView(model, view);
        var positionable = view.GetComponent<MapPositionable>();
        positionable.PositionGetter = GetPositionable;
    }

    IMapPositionable GetPositionable(Guid id)
    {
        return Game.Model.Characters.GetItem(id);
    }
}
