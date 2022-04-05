using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentController
{
    public void FrameUpdate(AgentModel model, float deltaTime)
    {
        if(model.Path!=null)
        {
            var start = (Vector2)model.Path.Start.Position;
            var end = (Vector2)model.Path.End.Position;
            var dir = (end - start).normalized;
            model.WorldPosition += dir * model.MoveSpeed * deltaTime;
        }
    }
}
