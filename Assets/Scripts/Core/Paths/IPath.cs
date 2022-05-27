using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPath
{
    Vector3 StartPoint { get; }
    Vector3 EndPoint { get; }
    float Length { get; }
    Vector3 GetPointAtDistance(float distance);
}
