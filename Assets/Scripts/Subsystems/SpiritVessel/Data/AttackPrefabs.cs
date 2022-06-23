using SpiritVessel.ViewModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpiritVessel.Data
{
    public class AttackPrefabs : KeyHoldertoPrefabReferenceLookup<IAttackModel, AttackData>
    {
        [SerializeField]
        List<AttackData> _attacks = new();

        protected override IEnumerable<AttackData> PrefabReferences => _attacks;
    }
}
