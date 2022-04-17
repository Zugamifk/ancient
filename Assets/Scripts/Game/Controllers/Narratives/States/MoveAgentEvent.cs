using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAgentEvent : NarrativeState<MoveAgentData>
{
    public override string UpdateState(IGameModel model)
    {
        EventHandler.WalkToPosition(Data.Character, Data.Destination);
        // shoudl progress when arrives
        return Data.Next;
    }
}
