using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController
{
    public void UpdateTimeModel(TimeModel model, float deltaTime)
    {
        model.TotalRealSeconds += deltaTime;
    }
}
