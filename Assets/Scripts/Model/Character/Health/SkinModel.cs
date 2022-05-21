using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinModel : BodyPartModel, IConnectable<SkinModel>
{
    public ISet<SkinModel> Connected { get; set; } = new HashSet<SkinModel>();

}
