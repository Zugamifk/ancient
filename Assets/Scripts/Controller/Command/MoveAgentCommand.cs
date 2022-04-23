using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAgentCommand : ICommand
{
    string _agentName;
    string _destination;
    EventHandler<Vector2Int> _reachedPathEnd;


    public MoveAgentCommand(string name, string destination, EventHandler<Vector2Int> reachedPathend = null)
    {
        _agentName = name;
        _destination = destination;
        _reachedPathEnd = reachedPathend;
    }

    public void Execute(GameController controller)
    {
        var destinationPosition = controller.ParsePosition(_destination);
        var startPoint = controller.Model.Agents[_agentName].WorldPosition;
        var endPoint = destinationPosition;
        var path = controller.MapController.GetPath(Vector2Int.FloorToInt(startPoint), Vector2Int.FloorToInt(endPoint), controller.Model.MapModel.Grid);
        var agent = controller.Model.Agents[_agentName];
        agent.CityPath = path;
        if(_reachedPathEnd!=null) { 
            agent.ReachedPathEnd += _reachedPathEnd;
            agent.ReachedPathEnd += (_, _) => controller.DoCommand(new EnterBuildingCommand(_agentName, _destination));
        }
    }
}
