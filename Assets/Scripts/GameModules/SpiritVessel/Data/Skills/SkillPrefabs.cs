using SpiritVessel.ViewModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpiritVessel.Data
{
    public class SkillPrefabs : KeyHoldertoPrefabReferenceLookup<IAttackModel, SkillPrefabReference>
    {
        [SerializeField]
        List<SkillPrefabReference> _attacks = new();

        protected override IEnumerable<SkillPrefabReference> PrefabReferences => _attacks;

        protected override void OnEnable()
        {
            base.OnEnable();

            Prefabs.Register<ILightningSkillCloudModel>(this);
        }
    }
}
