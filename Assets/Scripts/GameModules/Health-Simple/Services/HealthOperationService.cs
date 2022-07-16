using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HealthOperationService
{
    public void Remove(BodyModel body, BodyPartModel part)
    {
        var builder = new BodyBuilder();
        foreach (var p in part.Connected.ToList())
        {
            builder.Disconnect(p, part);
        }
    }

    public void Cut(BodyModel body, ICuttable part)
    {
        part.IsCut = true;
    }

    public void SetBloodOxygenLevel(BodyModel body, float oxygenPercent)
    {
        var hfs = new HealthFunctionService();
        foreach (var b in hfs.GetConnected(body.Heart.Blood))
        {
            b.OxygenLevel = new Percent(oxygenPercent);
        }
    }
}
