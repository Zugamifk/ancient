using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartModel : OrganModel, IHasMuscle
{
    public MuscleModel Muscle { get; set; }
}
