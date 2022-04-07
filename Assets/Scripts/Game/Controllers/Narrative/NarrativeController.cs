using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarrativeController
{
    NarrativeCollection _collection;

    public NarrativeController(NarrativeCollection collection)
    {
        _collection = collection;
    }

    public void StartNarrative(string name, Queue<GameEvent> eventQueue)
    {
        var data = _collection.GetNarrative(name);
        var step = data.Steps[0];
        switch (step)
        {
            case CharacterWalkData cw:
                {
                    eventQueue.Enqueue(new AgentMoveEvent() { Agent = cw.Character, Start = cw.Start, Destination = cw.End });
                }
                break;
            default:
                break;
        }
    }
}
