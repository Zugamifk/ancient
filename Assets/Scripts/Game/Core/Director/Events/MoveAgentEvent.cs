using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAgentEvent : GameEvent<MoveAgentData>
{
    public override void OnStarted(Director director, IGameModel model)
    {
        director.WalkToPosition(Data.Character, Data.Destination);
    }

    public override void Execute(Director director, IGameModel model, System.Action<string> onCompleted)
    {
    }
}
