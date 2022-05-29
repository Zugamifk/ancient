using Core;
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
        private readonly BloodCirculation _bloodCirculation;
        public int HeartRate { get; set; } = 80;
        public Blood Blood => _bloodCirculation.BloodContents;
        public Measure Capacity => _bloodCirculation.Volume.Capacity;

        public Heart(float capacity)
        {
            _bloodCirculation = new(capacity);
        }

        public void SetBloodAmount(Measure amount)
        {
            _bloodCirculation.Volume.Fluids.AddFluid(new Blood(amount));
        }

        public void PulseContract()
        {
            var sumSinkCapacity = _bloodCirculation.Sinks.Sum(s => s.Volume.Capacity);
            foreach(var s in _bloodCirculation.Sinks)
            {
                var proportion = s.Volume.Capacity / sumSinkCapacity;
                var sinkMeasureToAdd = _bloodCirculation.Volume.Fluids.Measure * proportion;
                s.Volume.Add(new Blood(sinkMeasureToAdd));
            }
        }
    }
}
