using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class StartWaveCommand : ICommand
    {
        public void Execute(GameModel model)
        {
            var towerModel = model.TurretDefenseModel;
            towerModel.StartTime = model.TimeModel.RealTime;
            towerModel.SpawnedCount = 0;
            towerModel.CurrentWave++;
        }
    }
}