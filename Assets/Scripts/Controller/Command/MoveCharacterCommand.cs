using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCharacterCommand : ICommand
{
    string _characterName;
    string _destination;
    EventHandler<Vector2Int> _reachedPathEnd;


    public MoveCharacterCommand(string name, string destination, EventHandler<Vector2Int> reachedPathend = null)
    {
        _characterName = name;
        _destination = destination;
        _reachedPathEnd = reachedPathend;
    }

    public void Execute(GameController controller)
    {
        var destinationPosition = controller.ParsePosition(_destination);
        var startPoint = controller.Model.Characters[_characterName].Movement.WorldPosition;
        var endPoint = destinationPosition;
        var path = controller.MapController.PathFinder.GetPath(Vector2Int.FloorToInt(startPoint), Vector2Int.FloorToInt(endPoint), controller.Model.MapModel.Grid);
        var agent = controller.Model.Characters[_characterName];
        agent.Movement.CityPath = path;
        if(_reachedPathEnd!=null) { 
            agent.Movement.ReachedPathEnd += _reachedPathEnd;
            agent.Movement.ReachedPathEnd += (_, _) => controller.DoCommand(new EnterBuildingCommand(_characterName, _destination));
        }
    }
}
