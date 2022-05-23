using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodVesselModel : BodyPartModel
{
    public Percentage BloodLevel { get; set; } = new Percentage(100);
    public Percentage OxygenLevel { get; set; } = new Percentage(100);
}
