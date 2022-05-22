using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDiagnosticService
{
    public bool IsAlive(BodyModel body)
    {
        var brainHasBlood = IsGettingBlood(body, body.Brain);
        var heartHasBrainConnection = IsNerveConnectedToBrain(body, body.Heart);
        return brainHasBlood && heartHasBrainConnection;
    }

    public bool IsGettingBlood(BodyModel body, IHasBlood part)
    {
        return IsConnected<BloodVesselModel>(body.Heart.Blood, part.Blood) && part.Blood.BloodLevel > 0;
    }

    public bool IsNerveConnectedToBrain(BodyModel body, IHasNerves part)
    {
        return IsConnected<NerveModel>(body.Brain.Nerve, part.Nerve);
    }

    public bool IsConnected<TPart>(BodyPartModel partA, BodyPartModel partB)
        where TPart : BodyPartModel
    {
        HashSet<BodyPartModel> visited = new();
        Stack<BodyPartModel> path = new();
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
