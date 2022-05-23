using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BodyPartModel 
{
    public string Name { get; set; }
    public HashSet<BodyPartModel> Connected = new HashSet<BodyPartModel>();

    public virtual void ConnectTo(BodyPartModel other)
    {
        Connected.Add(other);
        other.Connected.Add(this);
    }

    public override string ToString() => Name;
}
