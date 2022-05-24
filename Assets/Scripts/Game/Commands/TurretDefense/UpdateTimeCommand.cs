using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class UpdateTimeCommand : ICommand
    {
        public void Execute(GameModel model)
        {
            var tdModel = model.TurretDefenseModel;
            tdModel.CurrentTime = model.TimeModel.RealTime - tdModel.StartTime;
        }
    }
}