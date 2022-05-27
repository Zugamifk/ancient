using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollower
{
    float _distance;
    IPath _path;
    public PathFollower(IPath path)
    {
        _path = path;
    }

    public Vector3 Position => _path.GetPointAtDistance(_distance);
    public bool AtEnd => Mathf.Approximately(_distance, _path.Length);

    public void Step(float step)
    {
        _distance = Mathf.Clamp(_distance + step, 0, _path.Length);
    }
}
