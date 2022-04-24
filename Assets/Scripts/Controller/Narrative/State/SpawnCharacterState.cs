using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCharacterState : NarrativeState<SpawnCharacterData>
{
    public override string UpdateState(IGameModel model)
    {
        Commands.DoCommand(new SpawnCharacterCommand(Data.Character, Data.Position));
        return Data.Next;
    }
}
