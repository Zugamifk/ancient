using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public readonly struct CityGraphEdge : ICityGraphEdge
{
    public ICityGraphNode PointA { get; }
    public ICityGraphNode PointB { get; }
    
    public CityGraphEdge(ICityGraphNode pointA, ICityGraphNode pointB)
    {
        PointA = pointA;
        PointB = pointB;
    }

    public override bool Equals(object obj)
    {
        return GetHashCode() == obj.GetHashCode();
    }

    public override int GetHashCode()
    {
        return PointA.GetHashCode() ^ PointB.GetHashCode();
    }
}
