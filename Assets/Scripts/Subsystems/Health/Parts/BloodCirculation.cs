using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fluids;

namespace Health
{
    public class BloodCirculation
    {
        public FluidVolume Volume { get; }
        public Blood BloodContents => Volume.Fluids.GetFluid<Blood>();

        public ISet<BloodCirculation> Sources { get; } = new HashSet<BloodCirculation>();

        public ISet<BloodCirculation> Sinks { get; } = new HashSet<BloodCirculation>();

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
    }
}
