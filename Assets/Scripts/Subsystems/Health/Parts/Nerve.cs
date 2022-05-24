using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Health
{
    public class Nerve : IHasName
    {
        public string Name { get; }
        public HashSet<Nerve> Connected { get; } = new();

        public Nerve()
        {
            Name = "Nerve";
        }

        public Nerve(string ownerName)
        {
            Name = $"{ownerName} Nerve";
        }
    }
}
