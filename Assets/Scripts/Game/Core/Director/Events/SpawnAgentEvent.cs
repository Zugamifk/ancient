using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAgentEvent : GameEvent<SpawnAgentData>
{
    public override void Execute(Director director, IGameModel model, System.Action<string> onCompleted)
    {
        director.SpawnAgent(Data.Character, Data.Position);
        onCompleted.Invoke(Data.Next);
    }
}
