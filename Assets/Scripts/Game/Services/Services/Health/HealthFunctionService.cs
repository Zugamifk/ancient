using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HealthFunctionService
{
    public void Inhale(BodyModel body)
    {
        var diag = Services.Get<HealthDiagnosticService>();
        if(!diag.CanBreath(body))
        {
            return;
        }
        foreach(var part in GetConnected(body.Heart.Blood))
        {
            part.OxygenLevel = 100;
        }
    }

    public IEnumerable<TPart> GetConnected<TPart>(TPart root)
        where TPart : BodyPartModel
    {
        HashSet<TPart> visited = new();
        Stack<TPart> path = new();
        path.Push(root);
        while (path.Count > 0)
        {
            var point = path.Pop();
            if (!visited.Contains(point))
            {
                visited.Add(point);
                yield return point;
                foreach (var p in point.Connected.Select(p => p as TPart).Where(p=>p!=null))
                {
                    path.Push(p);
                }
            }
        }
    }
}
