using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAgentState : NarrativeState<MoveAgentData>
{
    bool _reachedEnd = false;

    public override void EnterState(IGameModel model)
    {
        EventHandler.WalkToPosition(Data.Character, Data.Destination, ReachedPathEnd);
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

    void ReachedPathEnd(object sender, Vector2Int position)
    {
        _reachedEnd = true;
    }
}
