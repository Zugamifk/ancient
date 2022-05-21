using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodVesselModel : BodyPartModel, IConnectable<BloodVesselModel>
{
    public ISet<BloodVesselModel> Connected { get; set; } = new HashSet<BloodVesselModel>();
}
