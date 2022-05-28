using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Health
{
    public interface IBody
    {
        Head Head { get; }
        Brain Brain { get; }
        Heart Heart { get; }
    }
}