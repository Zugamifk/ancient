using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CityGraph : ICityGraph
{
    HashSet<ICityGraphNode> _vertices = new HashSet<ICityGraphNode>();
    HashSet<ICityGraphEdge> _edges = new HashSet<ICityGraphEdge>();

    public IEnumerable<ICityGraphNode> Vertices => _vertices;
    public IEnumerable<ICityGraphEdge> Edges => _edges;

    public void AddNode(ICityGraphNode node)
    {
        _vertices.Add(node);
    }

    public void Connect(ICityGraphNode start, ICityGraphNode end)
    {
        if (start == end)
        {
            throw new System.ArgumentException("Start and end can not be the same!");
        }

        if (!_vertices.Contains(start))
        {
            AddNode(start);
        }

        if (!_vertices.Contains(end))
        {
            AddNode(end);
        }

        _edges.Add(new CityGraphEdge(start, end));
    }
}
