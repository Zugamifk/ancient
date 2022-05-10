using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCharacterState : NarrativeState<MoveCharacterData>
{
    bool _reachedEnd = false;

    public override void EnterState(IGameModel model)
    {
        Commands.DoCommand(new MoveCharacterCommand()
        {
            CharacterName = Data.Character,
            DestinationName = Data.Destination,
            ReachedPathEnd = ReachedPathEnd
        });
    }

    public override string UpdateState(IGameModel model)
    {
        if (_reachedEnd)
        {
            return Data.Next;
        } else
        {
            return Data.Name;
        }
    }

    void ReachedPathEnd(MovementModel _)
    {
        _reachedEnd = true;
    }
}
