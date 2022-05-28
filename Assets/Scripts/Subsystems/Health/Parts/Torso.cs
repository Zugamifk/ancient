using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Health
{
    public class Torso : IHasName
    {
        const float BLOOD_VOLUME = 10;

        const string NAME = "Torso";
        public string Name => NAME;

        public Heart Heart { get; } = new();
        public BloodCirculation BloodCirculation { get; } = new(BLOOD_VOLUME);
        public Nerve Nerves { get; } = new(NAME);

        public Torso()
        {
            Heart.BloodCirculation.ConnectSink(BloodCirculation);
            Heart.BloodCirculation.ConnectSource(BloodCirculation);
        }
    }
}
