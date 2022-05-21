using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneModel : BodyPartModel, IConnectable<BoneModel>
{
    public ISet<BoneModel> Connected { get; set; } = new HashSet<BoneModel>();
}
