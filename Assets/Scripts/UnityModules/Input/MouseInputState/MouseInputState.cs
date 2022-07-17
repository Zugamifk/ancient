using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Input
{
    public abstract class MouseInputState
    {
        public abstract MouseInputState UpdateState();
    }
}