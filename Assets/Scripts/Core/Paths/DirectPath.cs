using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectPath : IPath
{
    public Vector3 StartPoint { get; set; }

    public Vector3 EndPoint { get; set; }

    public DirectPath(Vector3 start, Vector3 end)
    {
        StartPoint = start;
        EndPoint = end;
    }

    public float Length => (EndPoint - StartPoint).magnitude;

    public Vector3 GetPointAtDistance(float distance)
    {
        return Vector3.Lerp(StartPoint, EndPoint, distance / Length);
    }
}
