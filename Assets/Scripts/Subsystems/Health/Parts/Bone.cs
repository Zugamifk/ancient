using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Health
{
    public class Bone : IHasName
    {
        public string Name { get; }
        public Bone()
        {
            Name = "Bone";
        }

        public Bone(string name) {
            Name = name;
        }
    }
}
