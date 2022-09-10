using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PortalDefense.ViewModel;

namespace PortalDefense.Model
{
    public class WaveModel : IWaveModel
    {
        public int EnemiesRemaining { get; set; }
        public float SpawnsPerMinute { get; set; }
        public float WaveCounter { get; set; }
    }
}
