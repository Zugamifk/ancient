using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Health
{
    public class Torso : IHasName
    {
        const string NAME = "Torso";
        public string Name => NAME;

        public Heart Heart { get; }
    }
}
