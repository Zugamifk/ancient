using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Health
{
    public class NervousSystem
    {
        public Brain Brain { get; }
        public NervousSystem(Brain brain)
        {
            Brain = brain;
        }
    }
}
