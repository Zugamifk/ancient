using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpiritVessel.ViewModel
{
    public interface ILightningSkillCloudModel : IIdentifiable, IKeyHolder, IMapPositionable
    {
        float Radius { get; }
    }
}
