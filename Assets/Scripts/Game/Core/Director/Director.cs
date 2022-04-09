using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Director
{
    GameController _controller;
    NarrativeCollection _collection;
    List<Narrative> _activeNarratives = new List<Narrative>();

    public Director(NarrativeCollection collection, GameController controller)
    {
        _collection = collection;
        _controller = controller;
    }

    public void FrameUpdate(IGameModel model)
    {
        foreach(var n in _activeNarratives)
        {
            n.FrameUpdate(this, model);
        }
    }

    public void StartNarrative(string name)
    {
        var narrative = BuildNarrative(name);
        _activeNarratives.Add(narrative);
    }

    public void SpawnAgent(string name, string position)
    {
        _controller.AddAgent(name);
    }

    public void WalkToPosition(string name, string position)
    {
        _controller.SetAgentPath(name, Names.Buildings.Manor, position);
    }

    Narrative BuildNarrative(string name)
    {
        return new Narrative(_collection.GetNarrative(name));
    }
}
