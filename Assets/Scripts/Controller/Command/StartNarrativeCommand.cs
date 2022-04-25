using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartNarrativeCommand : ICommand
{
    string _narrativeName;
    public StartNarrativeCommand(string narrativeName)
    {
        _narrativeName = narrativeName;
    }

    public void Execute(GameController controller)
    {
        controller.NarrativeController.StartNarrative(_narrativeName, controller.Model);
    }
}