using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Narrative
{
    public string Name;

    NarrativeGraph _graph;
    GameEvent _currentEvent;
    GameEvent _nextEvent;

    public Narrative(NarrativeData data)
    {
        _graph = new NarrativeGraph();

        foreach (var stepData in data.Steps)
        {
            var step = GetGameEvent(stepData);
            _graph.Nodes.Add(stepData.Name, step);
        }

        SetNextEvent(data.StartStep);
    }

    public void FrameUpdate(Director director, IGameModel model)
    {
        if(_nextEvent!= _currentEvent)
        {
            _currentEvent = _nextEvent;
            if (_currentEvent != null)
            {
                _currentEvent.OnStarted(director, model);
            }
        }

        if (_currentEvent != null)
        {
            _currentEvent.Execute(director, model, SetNextEvent);
        }
    }

    void SetNextEvent(string next)
    {
        if (!string.IsNullOrEmpty(next))
        {
            _nextEvent = _graph.Nodes[next];
        } else
        {
            _nextEvent = null;
        }
    }

    GameEvent GetGameEvent(NarrativeStepData stepData)
    {
        switch (stepData)
        {
            case SpawnAgentData data:
                return InstantiateGameEvent<SpawnAgentEvent, SpawnAgentData>(data);
            case MoveAgentData data:
                return InstantiateGameEvent<MoveAgentEvent, MoveAgentData>(data);
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
