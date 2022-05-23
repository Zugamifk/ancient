using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LungModel : OrganModel, IHasMuscle
{
    public MuscleModel Muscle { get; set; }
}
