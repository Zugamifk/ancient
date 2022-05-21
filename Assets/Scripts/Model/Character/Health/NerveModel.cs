using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NerveModel : BodyPartModel, IConnectable<NerveModel>
{
    public ISet<NerveModel> Connected { get; set; } = new HashSet<NerveModel>();
}
