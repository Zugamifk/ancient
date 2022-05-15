using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCharacterState : NarrativeState<SpawnCharacterData>
{
    public override string UpdateState(IGameModel model)
    {
        var locator = Services.Get<LocationFinder>();
        var position = locator.FindMapLocation(Data.Position, model);
        Game.Do(new SpawnCharacterCommand()
        {
            Name = Data.Character,
            Position =  Vector2Int.FloorToInt(position),
            IsUnique = Data.IsUnique
        });
        return Data.Next;
    }
}
