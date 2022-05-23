using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Health
{
    public class HumanBodyModel : IBodyModel, IHasName
    {
        public string Name { get; }
        public HumanBodyModel(string name = null)
        {
            Name = name ?? "Human";
        }
    }
}
