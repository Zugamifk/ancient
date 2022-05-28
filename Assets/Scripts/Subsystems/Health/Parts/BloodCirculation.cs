using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fluids;
using System;

namespace Health
{
    public class BloodCirculation
    {
        public FluidVolume Volume { get; }
        public Blood BloodContents => Volume.Fluids.GetFluid<Blood>();

        public ISet<BloodCirculation> Sources { get; } = new HashSet<BloodCirculation>();

        public ISet<BloodCirculation> Sinks { get; } = new HashSet<BloodCirculation>();
        public bool HasBlood => BloodContents.Measure > 0;

        public BloodCirculation(float capacity)
        {
            Volume = new FluidVolume(capacity);
        }

        public void ConnectSource(BloodCirculation source)
        {
            Sources.Add(source);
            source.Sinks.Add(this);
        }

        public void ConnectSink(BloodCirculation sink)
        {
            Sinks.Add(sink);
            sink.Sources.Add(this);
        }

        public bool HasSink(BloodCirculation sink)
        {
            return Sinks.Contains(sink);
        }

        public bool HasSource(BloodCirculation source)
        {
            return Sources.Contains(source);
        }

        public bool IsAnoxic()
        {
            return BloodContents.OxygenLevel < 50;
        }
    }
}
