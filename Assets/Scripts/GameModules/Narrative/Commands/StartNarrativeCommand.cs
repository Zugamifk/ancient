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
            NarrativeRunner.StartNarrative(_narrativeName);
        }
    }
}