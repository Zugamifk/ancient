using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Health
{
    public class HumanBody : IBody, IHasName
    {
        public string Name { get; }
        public HumanBody(string name = null)
        {
            Name = name ?? "Human";
        }
    }
}
