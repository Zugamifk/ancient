using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpiritVessel.View
{
    public class SpiritVesselWorldUI : MonoBehaviour
    {
        [SerializeField]
        SpiritVesselHealthBar _healthBarPrototype;

        Dictionary<Guid, SpiritVesselHealthBar> _idToHealthBarLookup = new();
    }
}
