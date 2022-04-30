using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildRoadCommand : ICommand
{
    string _startName;
    string _endName;

    public BuildRoadCommand(string startName, string endName)
    {
        _startName = startName;
        _endName = endName;
    }

    public void Execute(GameController controller)
    {
        controller.MapController.CityGenerator.BuildRoad(controller.Model.MapModel, _startName, _endName);
    }
}
