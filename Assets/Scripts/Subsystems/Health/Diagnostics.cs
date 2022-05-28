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
            return false;
        }
    }
}
