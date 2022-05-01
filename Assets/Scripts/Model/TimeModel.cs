using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeModel : ITimeModel
{
    const float TIME_MULTIPLIER = 6000;
    const int SECOND_PER_MINUTE = 60;
    const int MINUTES_PER_HOUR = 60;

    public float LastDeltaTime;
    public float RealTime;
    public float Time => RealTime * TIME_MULTIPLIER;
    public int Hour => Mathf.FloorToInt(Time) /(SECOND_PER_MINUTE*MINUTES_PER_HOUR);
    public int Minute => Mathf.FloorToInt(Time) / SECOND_PER_MINUTE;

}
