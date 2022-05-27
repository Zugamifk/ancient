using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fluids;

namespace Health
{
    public class BloodVessel : IBloodCirculator
    {
        public FluidVolume Volume { get; }
        public Blood BloodContents => Volume.Fluids.GetFluid<Blood>();

        public ISet<IBloodCirculator> Sources { get; } = new HashSet<IBloodCirculator>();

        public ISet<IBloodCirculator> Sinks { get; } = new HashSet<IBloodCirculator>();

        public BloodVessel(float capacity)
        {
            Volume = new FluidVolume(capacity);
        }

        public void ConnectSource(IBloodCirculator source)
        {
            Sources.Add(source);
        }
    }
}
