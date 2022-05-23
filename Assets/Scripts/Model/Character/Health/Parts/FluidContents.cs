using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Health
{
    public class FluidContents
    {
        public float Capacity { get; set; }
        public IEnumerable<IFluid> Fluids;
    }
}
