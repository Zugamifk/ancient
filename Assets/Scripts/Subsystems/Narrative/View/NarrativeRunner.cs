using Narrative.Services;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Narrative.View
{
    public class NarrativeRunner : MonoBehaviour
    {
        private void Update()
        {
            foreach (var n in Game.MutableModel.Narratives.Values)
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
                FinishNarrative(narrative);
            }
            else if (next != narrative.CurrentState.Name)
            {
                GotoNextNarrativeState(narrative, next);
            }
        }

        void GotoNextNarrativeState(NarrativeModel narrative, string next)
        {
            var collection = DataService.GetData<NarrativeCollection>();
            var data = collection.GetNarrative(narrative.Name);
            var stateData = data.Steps.FirstOrDefault(s => s.Name == next);
            if (stateData == null)
            {
                throw new System.InvalidOperationException($"No state \'{next}\' found in narrative {narrative.Name}");
            }

            narrative.CurrentState.ExitState(Game.Model);
            var builder = new NarrativeBuilder();
            narrative.CurrentState = builder.BuildNarrativeState(stateData);
            narrative.CurrentState.EnterState(Game.Model);
        }

        void FinishNarrative(NarrativeModel narrative)
        {
            narrative.CurrentState.ExitState(Game.Model);
            narrative.CurrentState = null;
        }
    }
}