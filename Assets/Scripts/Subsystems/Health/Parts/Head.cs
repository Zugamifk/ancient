using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Health
{
    public class Head : IHasName
    {
        const string NAME = "Head";
        const float BLOOD_VOLUME = 10;

        public string Name => NAME;
        public Bone Skull { get; } = new("Skull");
        public BloodVessel BloodVessels { get; } = new BloodVessel(BLOOD_VOLUME);
        public Brain Brain { get; } = new Brain();
        public Nerve Nerves { get; } = new Nerve(NAME);

        public Head()
        {
            Nerves.ConnectTo(Brain.Nerves);
        }
    }
}
