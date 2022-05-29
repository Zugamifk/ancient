using Fluids;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Health
{
    public class Heart : IHasName
    {
        const string NAME = "Heart";
        public string Name => NAME;
        public BloodCirculation BloodCirculation { get; }
        public int HeartRate { get; set; } = 80;

        public Heart(float capacity)
        {
            BloodCirculation = new(capacity);
        }

        public void PulseContract()
        {
            foreach(var s in BloodCirculation.Sinks)
            {
                s.Volume.Add(new Blood(BloodCirculation.Volume.Fluids.Measure));
            }
        }
    }
}
