using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpiritVessel.ViewModel
{
    public interface IHitpointsHealthModel : IIdentifiable
    {
        int Current { get; }
        int Max { get; }
    }
}
