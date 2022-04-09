using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICityGraphEdge
{
    public ICityGraphNode PointA { get; }
    public ICityGraphNode PointB { get; }
}
