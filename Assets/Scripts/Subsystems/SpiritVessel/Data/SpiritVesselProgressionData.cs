using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpiritVessel.Data
{
    public class SpiritVesselProgressionData : ScriptableObject, IRegisteredData
    {
        [System.Serializable]
        public class LevelData
        {
            public int XpRequired;
        }

        public LevelData[] Levels;
    }
}
