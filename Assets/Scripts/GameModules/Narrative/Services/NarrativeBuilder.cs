using Narrative.States;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Narrative.Services
{
    public class NarrativeBuilder
    {
        public NarrativeState BuildNarrativeState(NarrativeStepData stepData)
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
}
