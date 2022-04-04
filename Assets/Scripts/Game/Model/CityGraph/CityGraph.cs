using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CityGraph : ICityGraph
{
    class EdgeComparer : IEqualityComparer<(ICityGraphNode, ICityGraphNode)>
    {
        public bool Equals((ICityGraphNode, ICityGraphNode) x, (ICityGraphNode, ICityGraphNode) y)
        {
            return GetHashCode(x) == GetHashCode(y);
        }

        public int GetHashCode((ICityGraphNode, ICityGraphNode) obj)
        {
            return obj.Item1.GetHashCode() ^ obj.Item2.GetHashCode();
        }
    }
    static EdgeComparer _edgeComparer = new EdgeComparer();
    Dictionary<ICityGraphNode, List<ICityGraphNode>> _nodes = new Dictionary<ICityGraphNode, List<ICityGraphNode>>();

    public IEnumerable<ICityGraphNode> Vertices => _nodes.Keys;
    public IEnumerable<(ICityGraphNode, ICityGraphNode)> EdgePairs => _nodes.SelectMany(kv => kv.Value.Select(v => (kv.Key, v))).Distinct(_edgeComparer);

    public void AddNode(ICityGraphNode node)
    {
        _nodes[node] = new List<ICityGraphNode>();
    }

    public void Connect(ICityGraphNode start, ICityGraphNode end)
    {
        if (start == end)
        {
            throw new System.ArgumentException("Start and end can not be the same!");
        }

        if (!_nodes.ContainsKey(start))
        {
            AddNode(start);
        }
        _nodes[start].Add(end);

        if (!_nodes.ContainsKey(end))
        {
            AddNode(end);
        }
        _nodes[end].Add(start);
    }
}
