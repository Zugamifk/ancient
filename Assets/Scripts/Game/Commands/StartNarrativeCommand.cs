using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StartNarrativeCommand : ICommand
{
    string _narrativeName;
    public StartNarrativeCommand(string narrativeName)
    {
        _narrativeName = narrativeName;
    }

    public void Execute(GameModel model)
    {
        var narrative = BuildNarrative();
        model.Narratives.Add(_narrativeName, narrative);
        narrative.CurrentState.EnterState(model);
    }

    NarrativeModel BuildNarrative()
    {
        var collection = DataService.GetData<NarrativeCollection>();
        var data = collection.GetNarrative(_narrativeName);
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
            case SpawnCharacterData data:
                return InstantiateGameEvent<SpawnCharacterState, SpawnCharacterData>(data);
            case MoveCharacterData data:
                return InstantiateGameEvent<MoveCharacterState, MoveCharacterData>(data);
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
        return new TEventType()
        {
            Data = data,
        };
    }
}
