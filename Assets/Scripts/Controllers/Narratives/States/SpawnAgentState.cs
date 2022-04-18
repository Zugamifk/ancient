using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAgentState : NarrativeState<SpawnAgentData>
{
    public override string UpdateState(IGameModel model)
    {
        EventHandler.SpawnAgent(Data.Character, Data.Position);
        return Data.Next;
    }
}
