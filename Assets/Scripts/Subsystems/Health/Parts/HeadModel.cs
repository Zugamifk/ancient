using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Health
{
    public class HeadModel : IHasName
    {
        const float BLOOD_VOLUME = 10;

        public string Name { get; }
        public BoneModel Skull { get; } = new("Skull");
        public BloodVesselModel BloodVessels { get; } = new BloodVesselModel(BLOOD_VOLUME);
        public HeadModel()
        {
            Name = "Head";
        }

        public HeadModel(string ownerName)
        {
            Name = $"{ownerName} Head";
            Skull = new($"{ownerName} Skull");
        }
    }
}
