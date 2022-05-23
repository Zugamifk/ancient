using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fluids
{
    public interface IFluid
    {
        FluidMeasure Measure { get; }
    }
}
