using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityGraphDrawer : MonoBehaviour
{
    ICityGraph _graph;

    private IEnumerator Start()
    {
        while (_graph == null)
        {
            _graph = FindObjectOfType<GameBehaviour>().CityGraph;
            yield return null;
        }
    }

    private void OnDrawGizmos()
    {
        if (_graph == null) return;

        Gizmos.color = Color.green;
        foreach (var v in _graph.Vertices)
        {
            Gizmos.DrawWireSphere((Vector2)v.Position, 0.5f);
        }

        foreach (var p in _graph.EdgePairs)
        {
            Gizmos.DrawLine((Vector2)p.Item1.Position, (Vector2)p.Item2.Position);
        }
    }
}
