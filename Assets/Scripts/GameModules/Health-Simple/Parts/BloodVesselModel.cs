using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodVesselModel : BodyPartModel
{
    public Percent BloodLevel { get; set; } = new Percent(100);
    public Percent OxygenLevel { get; set; } = new Percent(100);
}
