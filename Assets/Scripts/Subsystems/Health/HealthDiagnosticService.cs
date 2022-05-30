using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Health
{
    public class HealthDiagnosticService
    {
        public IBody Body;

        public bool IsAlive()
        {
            return Body.Heart.IsBeating;
        }
    }
}
