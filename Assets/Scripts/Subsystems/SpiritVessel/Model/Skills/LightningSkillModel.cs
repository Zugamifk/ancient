using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpiritVessel.ViewModel;

namespace SpiritVessel.Model
{
    public class LightningSkillModel : ILightningSkillModel
    {
        public bool Owned { get; set; }
        public float CoolDown { get; set; }
        public float Damage { get; set; }
        public float Radius { get; set; }
        public int Chains { get; set; }
        public bool HeavyRain { get; set; }
        public IdentifiableCollection<LightningSkillCloudModel> Clouds { get; set; } = new();
        public bool Ultimate { get; set; }

        #region ILightningSkillModel 
        IIdentifiableLookup<ILightningSkillCloudModel> ILightningSkillModel.Clouds => Clouds;
        #endregion
    }
}
