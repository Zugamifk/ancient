using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCharacterCommand : ICommand
{
    public Guid CharacterId;
    public string CharacterName;
    public string DestinationName;
    public Vector2Int Destination;
    public Action<MovementModel> ReachedPathEnd;

    public void Execute(GameController controller)
    {
        var character = string.IsNullOrEmpty(CharacterName) ?
            controller.Model.Characters.GetItem(CharacterId) :
            controller.Model.Characters.GetItem(CharacterName);
        var startPoint = character.Movement.WorldPosition;
        var endPoint = string.IsNullOrEmpty(DestinationName) ? Destination : controller.ParsePosition(DestinationName);
        var path = controller.MapController.PathFinder.GetPath(Vector2Int.FloorToInt(startPoint), Vector2Int.FloorToInt(endPoint), controller.Model.MapModel.Grid);
        character.Movement.CityPath = path;
        if (ReachedPathEnd != null)
        {
            character.Movement.ReachedPathEnd += ReachedPathEnd;
        }
    }
}
