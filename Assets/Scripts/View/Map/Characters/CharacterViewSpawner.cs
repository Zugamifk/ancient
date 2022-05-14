using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterViewSpawner : ViewSpawner<ICharacterModel, Character>
{
    public CharacterViewSpawner(IPrefabLookup prefabLookup, Transform viewParent)
        : base(prefabLookup, viewParent)
    {
    }

    protected override IIdentifiableLookup<ICharacterModel> GetIdentifiables() => Game.Model.Characters;
    protected override string GetPrefabKey(ICharacterModel model) => model.Name;
    protected override void SpawnedView(ICharacterModel model, Character view)
    {
        var positionable = view.GetComponent<MapPositionable>();
        positionable.PositionGetter = GetPositionable;
    }

    IMapPositionable GetPositionable(Guid id)
    {
        return Game.Model.Characters.GetItem(id);
    }
}
