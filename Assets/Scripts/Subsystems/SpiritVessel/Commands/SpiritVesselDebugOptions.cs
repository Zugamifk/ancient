using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpiritVessel.Commands
{
    public class SpiritVesselDebugOptions : MonoBehaviour
    {
        [SerializeField]
        bool _disableLevelUp;

        static SpiritVesselDebugOptions _instance;

        public static bool DisableLevelUp => _instance._disableLevelUp;

        private void Awake()
        {
            _instance = this;
        }
    }
}
