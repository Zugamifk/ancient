using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TowerDefense.Models;
using Model;

namespace TowerDefense
{
    public class StartWaveCommand : ICommand
    {
        public void Execute(GameModel model)
        {
            var towerModel = model.GetModel<TowerDefenseGameModel>();
            towerModel.StartTime = model.TimeModel.RealTime;
            towerModel.SpawnedCount = 0;
            towerModel.CurrentWave++;
        }
    }
}