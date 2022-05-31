using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Health
{
    public interface IHealthCondition
    {
        string Name { get; }
        string Description { get; }
        EConditionSeverity Severity { get; }
    }
}
