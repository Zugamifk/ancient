using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuscleModel : BodyPartModel, IConnectable<MuscleModel>
{
    public ISet<MuscleModel> Connected { get; set; } = new HashSet<MuscleModel>();
}
