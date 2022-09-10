using Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PortalDefense.Model;

namespace PortalDefense.Commands
{
    public class StartWaveCommand : ICommand
    {
        public void Execute(GameModel model)
        {
            var pdm = model.GetModel<PortalDefenseModel>();
            pdm.CurrentWave = new()
            {
                EnemiesRemaining = 100,
                SpawnsPerMinute = 120,
                WaveCounter = 0
            };
        }
    }
}
