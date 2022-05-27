using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Health
{
    public class HumanBody : IBody, IHasName
    {
        public string Name { get; }

        public Head Head { get; } = new Head();
        public Torso Torso { get; } = new();

        public HumanBody(string name = null)
        {
            Name = name ?? "Human";
        }
    }
}
