using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HealthDiagnosticService
{
    public bool IsAlive(BodyModel body)
    {
        return IsFunctioning(body, body.Brain);
    }

    public bool CanBreath(BodyModel body)
    {
        return IsFunctioning(body, body.LeftLung) && IsFunctioning(body, body.RightLung);
    }

    public bool CanWalk(BodyModel body)
    {
        return IsLegUsable(body, body.LeftLeg) && IsLegUsable(body, body.RightLeg);
    }

    bool IsLegUsable(BodyModel body, LegModel leg)
    {
        return IsGettingBlood(body, leg) && IsNerveConnectedToBrain(body, leg);
    }

    public bool IsGettingBlood(BodyModel body, IHasBlood part)
    {
        return IsConnected<BloodVesselModel>(body.Heart.Blood, part.Blood) && part.Blood.BloodLevel > 0;
    }

    public bool IsNerveConnectedToBrain(BodyModel body, IHasNerves part)
    {
        return IsConnected<NerveModel>(body.Brain.Nerve, part.Nerve);
    }

    public bool IsFunctioning(BodyModel body, OrganModel organ)
    {
        return IsGettingBlood(body, organ) && IsNerveConnectedToBrain(body, organ);
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
                foreach(var p in point.Connected.Where(p=>p is TPart))
                {
                    path.Push(p);
                }
            }
        }

        Debug.Log($"{partA} is not connected to {partB}");
        return false;
    }
}
