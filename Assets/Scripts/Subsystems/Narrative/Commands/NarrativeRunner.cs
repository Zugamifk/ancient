using Narrative.Services;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Narrative.Commands
{
    public class NarrativeRunner : MonoBehaviour
    {
        static Dictionary<string, NarrativeModel> _narratives = new Dictionary<string, NarrativeModel>();

        public static void StartNarrative(string name)
        {
            var narrative = BuildNarrative(name);
            _narratives.Add(name, narrative);
            narrative.CurrentState.EnterState(Game.Model);
        }

        static NarrativeModel BuildNarrative(string name)
        {
            var collection = DataService.GetData<NarrativeCollection>();
            var data = collection.GetNarrative(name);
            var model = new NarrativeModel();
            model.Name = data.Name;

            var stepData = data.Steps.First(s => s.Name == data.StartStep);
            var builder = new NarrativeBuilder();
            model.CurrentState = builder.BuildNarrativeState(stepData);

            return model;
        }

        private void Update()
        {
            foreach (var n in _narratives.Values)
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