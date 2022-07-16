using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace City.Debug
{
    public class CityGraphDrawer : MonoBehaviour
    {
        readonly Vector2 POSITION_OFFSET = new Vector2(.5f, .5f);
        ICityGraph _graph;

        private IEnumerator Start()
        {
            while (_graph == null)
            {
                //_graph = FindObjectOfType<UnityLifecycleController>().CityGraph;
                yield return null;
            }
        }

        private void OnDrawGizmos()
        {
            if (_graph == null) return;

            Gizmos.color = Color.green;
            foreach (var v in _graph.Vertices)
            {
                Gizmos.DrawWireSphere(v.Position + POSITION_OFFSET, 0.5f);
            }

            foreach (var p in _graph.Edges)
            {
                Gizmos.DrawLine(p.PointA.Position + POSITION_OFFSET, p.PointB.Position + POSITION_OFFSET);
            }
        }
    }
}