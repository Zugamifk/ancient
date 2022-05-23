using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Narrative : MonoBehaviour
{
    private void Update()
    {
        foreach(var n in Game.MutableModel.Narratives.Values)
        {
            UpdateNarrative(n);
        }
    }

    void UpdateNarrative(NarrativeModel narrative)
    {
        if (narrative.CurrentState == null) return;

        var next = narrative.CurrentState.UpdateState(Game.Model);
        if (string.IsNullOrEmpty(next))
        {
            narrative.CurrentState.ExitState(Game.Model);
            narrative.CurrentState = null;
        }
        else if (next != narrative.CurrentState.Name)
        {
            var collection = DataService.GetData<NarrativeCollection>();
            var data = collection.GetNarrative(narrative.Name);
            var stateData = data.Steps.First(s => s.Name == next);
            narrative.CurrentState.ExitState(Game.Model);
            var builder = new NarrativeBuilder();
            narrative.CurrentState = builder.BuildNarrativeState(stateData);
            narrative.CurrentState.EnterState(Game.Model);
        }
    }
}
