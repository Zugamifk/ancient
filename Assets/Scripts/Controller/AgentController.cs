using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentController
{
    public void Update(AgentModel agent, GameModel model)
    {
        var path = agent.CityPath;
        if (path != null)
        {
            var distance = agent.MoveSpeed * model.TimeModel.LastDeltaTime;
            while (distance > 0 && !agent.AtPathEnd)
            {
                var end = (Vector2)path.Path[agent.CurrentPathIndex];
                var dir = (end - agent.WorldPosition);
                var distanceToEnd = dir.magnitude;
                if (distance < distanceToEnd)
                {
                    agent.WorldPosition += dir.normalized * distance;
                    break;
                } else
                {
                    agent.WorldPosition = end;
                    agent.CurrentPathIndex++;
                    distance -= distanceToEnd;
                }
            }

            if(agent.AtPathEnd)
            {
                agent.OnReachedPathEnd();
                agent.CityPath = null;
                agent.CurrentPathIndex = 0;
            }
        }
    }
}
