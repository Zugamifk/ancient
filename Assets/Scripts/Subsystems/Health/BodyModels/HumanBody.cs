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

        public Brain Brain => Head.Brain;
        public Heart Heart => Torso.Heart;

        public HumanBody(string name = null)
        {
            Name = name ?? "Human";

            Torso.BloodCirculation.ConnectSink(Head.BloodCirculation);
            Torso.BloodCirculation.ConnectSource(Head.BloodCirculation);
        }
    }
}
