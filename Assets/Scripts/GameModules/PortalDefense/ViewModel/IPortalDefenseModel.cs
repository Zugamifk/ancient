using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PortalDefense.ViewModel
{
    public interface IPortalDefenseModel : IRegisteredModel
    {
        IMapModel Map { get; }
        IWaveModel CurrentWave { get; }
    }
}
