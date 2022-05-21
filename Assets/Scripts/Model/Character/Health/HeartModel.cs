using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartModel : BodyPartModel, IHasNerves, IHasMuscle, IHasBlood
{
    public ISet<BodyPartModel> Connected { get; set; } = new HashSet<BodyPartModel>();

    public NerveModel Nerve { get; set; }
    public MuscleModel Muscle { get; set; }
    public BloodVesselModel Blood { get; set; }
}
