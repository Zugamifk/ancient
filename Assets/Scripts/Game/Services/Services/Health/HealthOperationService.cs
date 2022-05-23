using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HealthOperationService
{
    public void Remove(BodyModel body, BodyPartModel part)
    {
        var builder = Services.Get<BodyBuilder>();
        foreach(var p in part.Connected.ToList())
        {
            builder.Disconnect(p, part);
        }
    }

    public void Cut(BodyModel body, ICuttable part)
    {
        part.IsCut = true;
    }
}
