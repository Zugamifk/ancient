using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Health
{
    public class BoneModel : IHasName
    {
        public string Name { get; }
        public BoneModel()
        {
            Name = "Bone";
        }

        public BoneModel(string name) {
            Name = name;
        }
    }
}
