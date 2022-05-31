using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Health
{
    public class CardiacArrest : IHealthCondition
    {
        public string Name => "Cardiac Arrest";

        public string Description => "The heart has stopped and is no longer circulating blood.";

        public EConditionSeverity Severity => EConditionSeverity.Extreme;
    }
}
