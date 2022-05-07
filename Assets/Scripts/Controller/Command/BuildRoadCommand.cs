using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildRoadCommand : ICommand
{
    string _startName;
    Vector2Int _start;
    string _endName;
    Vector2Int _end;

    public BuildRoadCommand(string startName, string endName)
    {
        _startName = startName;
        _endName = endName;
    }

    public BuildRoadCommand(Vector2Int start, Vector2Int end)
    {
        _start = start;
        _end = end;
    }

    public void Execute(GameController controller)
    {
        if (string.IsNullOrEmpty(_startName))
        {
            controller.MapController.CityGenerator.BuildRoad(controller.Model.MapModel, _start, _end);
        }
        else
        {
            controller.MapController.CityGenerator.BuildRoad(controller.Model.MapModel, _startName, _endName);
        }
    }
}
