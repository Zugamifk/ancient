using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDiagnosticService
{
    public bool IsAlive(BodyModel body)
    {
        return IsGettingBlood(body, body.Brain);
    }

    public bool IsGettingBlood(BodyModel body, IHasBlood partA)
    {
        return IsConnected(body.Heart.Blood, partA.Blood);
    }

    public bool IsConnected<TPart>(IConnectable<TPart> partA, IConnectable<TPart> partB)
        where TPart : IConnectable<TPart>
    {
        HashSet<IConnectable<TPart>> visited = new();
        Stack<IConnectable<TPart>> path = new();
        path.Push(partA);
        while(path.Count > 0)
        {
            var point = path.Pop();
            if(point == partB)
            {
                return true;
            }
            if (!visited.Contains(point))
            {
                visited.Add(point);
                foreach(var p in point.Connected)
                {
                    path.Push(p);
                }
            }
        }
        return false;
    }
}
