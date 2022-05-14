using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCharacterCommand : ICommand
{
    public Guid CharacterId;
    public string CharacterName;
    public Vector2Int Destination;
    public Action<MovementModel> ReachedPathEnd;

    public void Execute(GameModel model)
    {
        var character = string.IsNullOrEmpty(CharacterName) ?
            model.Characters.GetItem(CharacterId) :
            model.Characters.GetItem(CharacterName);
        var startPoint = character.Movement.WorldPosition;
        var path = Services.Get<PathFinder>()
            .GetPath(Vector2Int.FloorToInt(startPoint), Destination, model.MapModel.Grid);
        character.Movement.CityPath = path;
        if (ReachedPathEnd != null)
        {
            character.Movement.ReachedPathEnd += ReachedPathEnd;
        }
    }
}
