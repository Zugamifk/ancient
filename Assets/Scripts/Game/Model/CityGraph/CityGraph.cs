using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityGraph
{
    Dictionary<ICityGraphNode, List<ICityGraphNode>> _nodes = new Dictionary<ICityGraphNode, List<ICityGraphNode>>();

    public void AddNode(ICityGraphNode node)
    {
        _nodes[node] = new List<ICityGraphNode>();
    }

    public void Connect(ICityGraphNode start, ICityGraphNode end, bool direcitonal = false)
    {
        if( start == end)
        {
            throw new System.ArgumentException("Start and end can not be the same!");
        }

        if(!_nodes.ContainsKey(start))
        {
            AddNode(start);
        }

        _nodes[start].Add(end);

        if (!direcitonal)
        {
            if (!_nodes.ContainsKey(end))
            {
                AddNode(end);
            }

            _nodes[end].Add(start);
        }
}
