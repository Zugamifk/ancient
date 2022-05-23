using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Health
{
    public class Head : IHasName
    {
        const float BLOOD_VOLUME = 10;

        public string Name { get; }
        public Bone Skull { get; } = new("Skull");
        public BloodVessel BloodVessels { get; } = new BloodVessel(BLOOD_VOLUME);
        public Brain Brain { get; } = new Brain();

        public Head()
        {
            Name = "Head";
        }

        public Head(string ownerName)
        {
            Name = $"{ownerName} Head";
            Skull = new($"{ownerName} Skull");
            Brain = new(ownerName);
        }
    }
}
