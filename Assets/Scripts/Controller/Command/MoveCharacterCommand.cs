using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCharacterCommand : ICommand
{
    string _characterId;
    string _destination;
    EventHandler<Vector2Int> _reachedPathEnd;

    public MoveCharacterCommand(string id, string destination, EventHandler<Vector2Int> reachedPathend = null)
    {
        _characterId = id;
        _destination = destination;
        _reachedPathEnd = reachedPathend;
    }

    public void Execute(GameController controller)
    {
        var character = controller.Model.GetCharacterFromKey(_characterId);
        var startPoint = character.Movement.WorldPosition;
        var endPoint = controller.ParsePosition(_destination);
        var path = controller.MapController.PathFinder.GetPath(Vector2Int.FloorToInt(startPoint), Vector2Int.FloorToInt(endPoint), controller.Model.MapModel.Grid);
        character.Movement.CityPath = path;
        if(_reachedPathEnd!=null) {
            character.Movement.ReachedPathEnd += _reachedPathEnd;
            character.Movement.ReachedPathEnd += (_, _) => controller.DoCommand(new EnterBuildingCommand(_characterId, _destination));
        }
    }
}
