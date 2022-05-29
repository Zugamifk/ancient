using Fluids;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
            var sumSinkCapacity = BloodCirculation.Sinks.Sum(s => s.Volume.Capacity);
            foreach(var s in BloodCirculation.Sinks)
            {
                var proportion = s.Volume.Capacity / sumSinkCapacity;
                var sinkMeasureToAdd = BloodCirculation.Volume.Fluids.Measure * proportion;
                s.Volume.Add(new Blood(sinkMeasureToAdd));
            }
        }
    }
}
