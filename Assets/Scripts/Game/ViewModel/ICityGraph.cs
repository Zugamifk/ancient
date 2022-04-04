using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICityGraph
{
    IEnumerable<(ICityGraphNode, ICityGraphNode)> EdgePairs { get; }
}
