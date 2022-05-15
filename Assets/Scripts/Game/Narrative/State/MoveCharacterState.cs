using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCharacterState : NarrativeState<MoveCharacterData>
{
    bool _reachedEnd = false;

    public override void EnterState(IGameModel model)
    {
        var locator = Services.Get<LocationFinder>();
        var position = locator.FindMapLocation(Data.Destination, model);
        Game.Do(new MoveCharacterCommand()
        {
            CharacterName = Data.Character,
            Destination = Vector2Int.FloorToInt(position),
            ReachedPathEnd = ReachedPathEnd
        });
    }

    public override string UpdateState(IGameModel model)
    {
        if (_reachedEnd)
        {
            return Data.Next;
        }
        else
        {
            return Data.Name;
        }
    }

    void ReachedPathEnd(MovementModel _)
    {
        _reachedEnd = true;
    }
}
