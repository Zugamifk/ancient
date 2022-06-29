using Map.Model;
using Map.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCharacterCommand : ICommand
{
    public Guid MapId;
    public Guid CharacterId;
    public string CharacterName;
    public Vector2Int Destination;
    public Action<MapMovementModel> ReachedPathEnd;

    public void Execute(GameModel model)
    {
        var character = string.IsNullOrEmpty(CharacterName) ?
            model.Characters.GetItem(CharacterId) :
            model.Characters.GetItem(CharacterName);
        var map = model.Maps.GetItem(MapId);
        var movement = map.MovementModels.GetItem(character.Id);
        var startPoint = character.Position;
        var path = new PathFinder()
            .GetPath(Vector2Int.FloorToInt(startPoint), Destination, map.Grid);
        movement.CityPath = path;
        if (ReachedPathEnd != null)
        {
            movement.ReachedPathEnd += ReachedPathEnd;
        }
    }
}
