using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Narrative
{
    public string Name;

    NarrativeGraph _graph;
    GameEvent _currentEvent;

    public Narrative(NarrativeData data)
    {
        foreach (var stepData in data.Steps)
        {
            var step = GetGameEvent(stepData);
            _graph.Nodes.Add(stepData.Name, step);
        }

        _currentEvent = _graph.Nodes[data.StartStep];
    }

    public void FrameUpdate(Director director, IGameModel model)
    {
        _currentEvent.Execute(director, model, SetCurrentEvent);
    }

    void SetCurrentEvent(string next)
    {
        _currentEvent = _graph.Nodes[next];
    }

    GameEvent GetGameEvent(NarrativeStepData stepData)
    {
        switch (stepData)
        {
            case SpawnAgentData data:
                return InstantiateGameEvent<SpawnAgentEvent, SpawnAgentData>(data);
            default:
                break;
        }

        throw new System.InvalidOperationException("No game event available for data of type "+stepData.GetType());
    }

    GameEvent InstantiateGameEvent<TEventType, TDataType>(TDataType data) 
        where TEventType : GameEvent<TDataType>, new() 
        where TDataType : NarrativeStepData
    {
        return new TEventType() { Data = data };
    }
}
