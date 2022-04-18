using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeModel : ITimeModel
{
    const float TIME_MULTIPLIER = 60*120;
    const int SECOND_PER_MINUTE = 60;
    const int MINUTES_PER_HOUR = 60;

    public float TotalRealSeconds;
    public int Hour => Mathf.FloorToInt(TotalRealSeconds * TIME_MULTIPLIER) /(SECOND_PER_MINUTE*MINUTES_PER_HOUR);

}