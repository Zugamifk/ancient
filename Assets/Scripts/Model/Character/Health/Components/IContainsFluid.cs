using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Health
{
    public interface IContainsFluid
    {
        float Capacity { get; }
        IEnumerable<IFluid> Fluids { get; set; }
    }
}
