using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateMapMovementCommand : ICommand
{
    Guid _mapId;
    Guid _characterId;
    public UpdateMapMovementCommand(Guid mapId, Guid characterId)
    {
        _mapId = mapId;
        _characterId = characterId;
    }
    public void Execute(GameModel model)
    {
        var character = model.Characters.GetItem(_characterId);
        var movement = model.Maps.GetItem(_mapId).MovementModels.GetItem(_characterId);
        var path = movement.CityPath;
        if (path != null)
        {
            var distance = movement.MoveSpeed * model.TimeModel.LastDeltaTime;
            while (distance > 0 && !movement.AtPathEnd)
            {
                var end = path.Path[movement.CurrentPathIndex] + movement.PositionOffset;
                var dir = (end - character.Position);
                var distanceToEnd = dir.magnitude;
                if (distance < distanceToEnd)
                {
                    character.Position += dir.normalized * distance;
                    break;
                }
                else
                {
                    character.Position = end;
                    movement.CurrentPathIndex++;
                    distance -= distanceToEnd;
                }
            }

            if (movement.AtPathEnd)
            {
                movement.OnReachedPathEnd();
                movement.CityPath = null;
                movement.CurrentPathIndex = 0;
            }
        }
    }
}
