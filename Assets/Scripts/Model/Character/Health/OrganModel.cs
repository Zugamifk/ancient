using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrganModel : BodyPartModel, IHasNerves, IHasBlood
{
    public BloodVesselModel Blood { get; set; }
    public NerveModel Nerve { get; set; }
}
