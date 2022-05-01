using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController
{
    public void Update(MovementModel movement, GameModel model)
    {
        var path = movement.CityPath;
        if (path != null)
        {
            var distance = movement.MoveSpeed * model.TimeModel.LastDeltaTime;
            while (distance > 0 && !movement.AtPathEnd)
            {
                var end = (Vector2)path.Path[movement.CurrentPathIndex];
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
