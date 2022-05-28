using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Health
{
    public class Brain : IHasName
    {
        const string NAME = "Brain";
        public string Name => NAME;
        public Nerve Nerves { get; } = new(NAME);
        public BloodCirculation BloodCirculation { get; } = new(10);
    }
}
