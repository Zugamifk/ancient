using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BodyPartModel 
{
    public HashSet<BodyPartModel> Connected = new HashSet<BodyPartModel>();
}
