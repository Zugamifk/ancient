using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Health
{
    public class Brain : IHasName
    {
        public string Name { get; }
        public Brain()
        {
            Name = "Brain";
        }

        public Brain(string ownerName)
        {
            Name = $"{ownerName} Brain";
        }
    }
}
