using Narrative.Services;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Narrative.Commands
{
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
            var builder = new NarrativeBuilder();
            model.CurrentState = builder.BuildNarrativeState(stepData);

            return model;
        }
    }
}