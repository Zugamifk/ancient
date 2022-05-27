using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateMovementCommand : ICommand
{
    Guid _id;
    public UpdateMovementCommand(Guid id)
    {
        _id = id;
    }
    public void Execute(GameModel model)
    {
        var movement = model.Characters.GetItem(_id).Movement;
        var path = movement.CityPath;
        if (path != null)
        {
            var distance = movement.MoveSpeed * model.TimeModel.LastDeltaTime;
            while (distance > 0 && !movement.AtPathEnd)
            {
                var end = path.Path[movement.CurrentPathIndex] + movement.PositionOffset;
                var dir = (end - movement.WorldPosition);
                var distanceToEnd = dir.magnitude;
                if (distance < distanceToEnd)
                {
                    movement.WorldPosition += dir.normalized * distance;
                    break;
                }
                else
                {
                    movement.WorldPosition = end;
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
