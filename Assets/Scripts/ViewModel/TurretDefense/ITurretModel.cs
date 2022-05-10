using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITurretModel : IIdentifiable
{
    float AttackRadius { get; }
}
