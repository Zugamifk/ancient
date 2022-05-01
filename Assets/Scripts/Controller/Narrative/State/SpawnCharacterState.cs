using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCharacterState : NarrativeState<SpawnCharacterData>
{
    public override string UpdateState(IGameModel model)
    {
        Commands.DoCommand(new SpawnCharacterCommand() { 
            Name = Data.Character,
            PositionName = Data.Position,
            IsUnique = Data.IsUnique
        });
        return Data.Next;
    }
}
