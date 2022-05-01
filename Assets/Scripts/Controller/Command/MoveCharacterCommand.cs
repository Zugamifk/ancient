using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCharacterCommand : ICommand
{
    public string CharacterId;
    public string DestinationName;
    public Vector2Int Destination;
    public EventHandler<Vector2Int> ReachedPathEnd;

    public void Execute(GameController controller)
    {
        var character = controller.Model.Characters.GetItem(CharacterId);
        var startPoint = character.Movement.WorldPosition;
        var endPoint = string.IsNullOrEmpty(DestinationName) ? Destination : controller.ParsePosition(DestinationName);
        var path = controller.MapController.PathFinder.GetPath(Vector2Int.FloorToInt(startPoint), Vector2Int.FloorToInt(endPoint), controller.Model.MapModel.Grid);
        character.Movement.CityPath = path;
        if (ReachedPathEnd != null)
        {
            character.Movement.ReachedPathEnd += ReachedPathEnd;
            character.Movement.ReachedPathEnd += (_, _) => controller.DoCommand(new EnterBuildingCommand(CharacterId, DestinationName));
        }
    }
}
