using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Health
{
    public class Diagnostics
    {
        IBody _body;
        public Diagnostics(IBody body)
        {
            _body = body;
        }

        public bool IsAlive()
        {
            var brainHasBlood = _body.Brain.BloodCirculation.BloodContents.Measure > 0;
            var brainHasOxygen = brainHasBlood && _body.Brain.BloodCirculation.BloodContents.OxygenLevel > 50;
            return brainHasOxygen;
        }
    }
}
