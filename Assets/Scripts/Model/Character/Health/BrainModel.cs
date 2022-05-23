using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrainModel : BodyPartModel, IHasNerves, IHasBlood
{
    public NerveModel Nerve { get; set; }
    public BloodVesselModel Blood { get; set; }
}
