using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Health
{
    public class Nerve : IHasName
    {
        public string Name { get; }
        public IEnumerable<Nerve> Connected { get; } = new HashSet<Nerve>();

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
