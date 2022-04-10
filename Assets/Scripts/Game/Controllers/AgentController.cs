using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentController
{
    public void FrameUpdate(AgentModel model, float deltaTime)
    {
        var path = model.CityPath;
        if (path != null)
        {
            var distance = model.MoveSpeed * deltaTime;
            while (distance > 0 && !model.AtPathEnd)
            {
                var end = (Vector2)path.Path[model.CurrentPathIndex];
                var dir = (end - model.WorldPosition);
                var distanceToEnd = dir.magnitude;
                if (distance < distanceToEnd)
                {
                    model.WorldPosition += dir.normalized * distance;
                    break;
                } else
                {
                    model.WorldPosition = end;
                    model.CurrentPathIndex++;
                    distance -= distanceToEnd;
                }
            }
        }
    }
}
