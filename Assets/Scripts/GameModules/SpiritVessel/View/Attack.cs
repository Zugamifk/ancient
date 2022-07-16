using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpiritVessel.ViewModel;

namespace SpiritVessel.View
{
    [RequireComponent(typeof(MapPositionable))]
    public class Attack : MonoBehaviour, IView<IAttackModel>
    {
        [SerializeField]
        public void InitializeFromModel(IAttackModel model)
        {
        }
    }
}
