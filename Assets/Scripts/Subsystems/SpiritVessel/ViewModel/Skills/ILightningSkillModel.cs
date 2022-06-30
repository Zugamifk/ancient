using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpiritVessel.ViewModel
{
    public interface ILightningSkillModel
    {
        bool Owned { get; }
        IIdentifiableLookup<ILightningSkillCloudModel> Clouds { get; }
        int Chains { get; }
        float ChainRadius { get; }
    }
}
