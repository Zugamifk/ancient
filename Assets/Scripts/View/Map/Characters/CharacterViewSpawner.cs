using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterViewSpawner : ViewSpawner<ICharacterModel, Movement>
{
    ITileMapTransformer _tileMapTransformer;
    public CharacterViewSpawner(IPrefabLookup prefabLookup, Transform viewParent, ITileMapTransformer tileMapTransformer)
        : base(prefabLookup, viewParent)
    {
        _tileMapTransformer = tileMapTransformer;
    }

    protected override IIdentifiableLookup<ICharacterModel> GetIdentifiables(IGameModel model) => model.Characters;
    protected override string GetPrefabKey(ICharacterModel model) => model.Name;
    protected override void SpawnedView(ICharacterModel model, Movement view)
    {
        var positionable = view.GetComponent<MapPositionable>();
        positionable.TileMapTransformer = _tileMapTransformer;
    }
}
