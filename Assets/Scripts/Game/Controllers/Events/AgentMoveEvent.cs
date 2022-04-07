using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentMoveEvent : GameEvent
{
    public string Agent;
    public string Start;
    public string Destination;
    public override void Execute(IGameDirector director)
    {
        director.SpawnAgent(Agent, Start);
        director.WalkToPosition(Agent, Destination);
    }
}
