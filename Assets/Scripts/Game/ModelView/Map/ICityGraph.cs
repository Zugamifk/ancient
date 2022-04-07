using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICityGraph
{
    IEnumerable<ICityGraphNode> Vertices { get; }
    IEnumerable<(ICityGraphNode, ICityGraphNode)> EdgePairs { get; }
}
