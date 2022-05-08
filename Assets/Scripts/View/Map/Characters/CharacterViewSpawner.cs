using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterViewSpawner : ViewSpawner<ICharacterModel, Movement>
{
    public CharacterViewSpawner(IPrefabLookup prefabLookup, Transform viewParent)
        : base(prefabLookup, viewParent)
    {
    }

    protected override IIdentifiableLookup<ICharacterModel> GetIdentifiables(IGameModel model) => model.Characters;
    protected override string GetPrefabKey(ICharacterModel model) => model.Name;
}
