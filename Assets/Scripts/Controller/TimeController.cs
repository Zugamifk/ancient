using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController
{
    public void Update(TimeModel model, float deltaTime)
    {
        model.LastDeltaTime = deltaTime;
        model.RealTime += deltaTime;
    }
}
