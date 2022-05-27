using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fluids;

namespace Health
{
    public interface IBloodCirculator
    {
        ISet<IBloodCirculator> Sources { get; }
        ISet<IBloodCirculator> Sinks { get; }
        FluidVolume Volume { get; }
        Blood BloodContents => Volume.Fluids.GetFluid<Blood>();
    }
}
