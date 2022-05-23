using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Health
{
    public class BloodModel : IFluid
    {
        public Percentage OxygenLevel;

        public float Measure { get; set; }
    }
}
