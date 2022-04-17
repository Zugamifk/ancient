using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

class NarrativeController
{
    NarrativeCollection _collection;
    INarrativeEventHandler _eventHandler;

    public NarrativeController(NarrativeCollection collection, INarrativeEventHandler eventHandler)
    {
        _collection = collection;
        _eventHandler = eventHandler;
    }

    public void StartNarrative(string name, GameModel model)
    {
        var narrative = BuildNarrative(name);
        model.Narratives.Add(name, narrative);
    }

   public void FrameUpdate(NarrativeModel narrative, GameModel model)
   {
        if (narrative.CurrentState == null) return;

        var next = narrative.CurrentState.UpdateState(model);
        if (string.IsNullOrEmpty(next))
        {
            narrative.CurrentState = null;
        } else if (next!=narrative.CurrentState.Name) 
        {
            var data = _collection.GetNarrative(narrative.Name);
            var stateData = data.Steps.First(s => s.Name == next);
            narrative.CurrentState = BuildNarrativeState(stateData);
        }
   }

    NarrativeModel BuildNarrative(string name)
    {
        var data = _collection.GetNarrative(name);
        var model = new NarrativeModel();
        model.Name = data.Name;

        var stepData = data.Steps.First(s => s.Name == data.StartStep);
        model.CurrentState = BuildNarrativeState(stepData);

        return model;
    }

    NarrativeState BuildNarrativeState(NarrativeStepData stepData)
    {
        switch (stepData)
        {
            case SpawnAgentData data:
                return InstantiateGameEvent<SpawnAgentState, SpawnAgentData>(data);
            case MoveAgentData data:
                return InstantiateGameEvent<MoveAgentState, MoveAgentData>(data);
            case ReceiveItemData data:
                return InstantiateGameEvent<ReceiveItemState, ReceiveItemData>(data);
            default:
                break;
        }

        throw new System.InvalidOperationException("No game event available for data of type " + stepData.GetType());
    }

    TEventType InstantiateGameEvent<TEventType, TDataType>(TDataType data)
        where TEventType : NarrativeState<TDataType>, new()
        where TDataType : NarrativeStepData
    {
        return new TEventType() { 
            Data = data,
            EventHandler = _eventHandler
        };
    }
}
