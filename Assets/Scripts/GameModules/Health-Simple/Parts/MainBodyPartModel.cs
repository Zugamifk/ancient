using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainBodyPartModel : BodyPartModel, IHasSkin, IHasBone, IHasBlood, IHasNerves, IHasMuscle
{
    public SkinModel Skin { get; set; }
    public BoneModel Bone { get; set; }
    public BloodVesselModel Blood { get; set; }
    public NerveModel Nerve { get; set; }
    public MuscleModel Muscle { get; set; }
}
