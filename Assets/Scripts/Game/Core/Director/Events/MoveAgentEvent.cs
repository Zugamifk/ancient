using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAgentEvent : GameEvent
{
    public string Agent;
    public string Destination;

    public override void OnStarted(Director director, IGameModel model)
    {
        director.WalkToPosition(Agent, Destination);
    }

    public override void Execute(Director director, IGameModel model, System.Action<string> onCompleted)
    {
    }
}
