using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BodyPartModel : IConnectable<BodyPartModel>
{
    public ISet<BodyPartModel> Connected { get; set; } = new HashSet<BodyPartModel>();
}
