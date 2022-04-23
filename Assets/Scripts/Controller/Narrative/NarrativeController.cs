using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

class NarrativeController
{
    NarrativeCollection _collection;
    ICommandService _commands;

    public NarrativeController(NarrativeCollection collection, ICommandService commands)
    {
        _collection = collection;
        _commands = commands;
    }

    public void StartNarrative(string name, GameModel model)
    {
        var narrative = BuildNarrative(name);
        model.Narratives.Add(name, narrative);
        narrative.CurrentState.EnterState(model);
    }

   public void Update(NarrativeModel narrative, GameModel model)
   {
        if (narrative.CurrentState == null) return;

        var next = narrative.CurrentState.UpdateState(model);
        if (string.IsNullOrEmpty(next))
        {
            narrative.CurrentState.ExitState(model);
            narrative.CurrentState = null;
        } else if (next!=narrative.CurrentState.Name) 
        {
            var data = _collection.GetNarrative(narrative.Name);
            var stateData = data.Steps.First(s => s.Name == next);
            narrative.CurrentState.ExitState(model);
            narrative.CurrentState = BuildNarrativeState(stateData);
            narrative.CurrentState.EnterState(model);
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
            Commands = _commands
        };
    }
}
