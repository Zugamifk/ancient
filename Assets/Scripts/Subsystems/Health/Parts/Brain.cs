using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Health
{
    public class Brain : IHasName
    {
        public string Name { get; }
        public Nerve Nerves { get; }
        public Brain()
        {
            Name = "Brain";
            Nerves = new Nerve(Name);
        }

        public Brain(string ownerName)
        {
            Name = $"{ownerName} Brain";
            Nerves = new Nerve(Name);
        }
    }
}
