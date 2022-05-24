using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense.Commands
{
    public class UpdateTimeCommand : ICommand
    {
        public void Execute(GameModel model)
        {
            var tdModel = model.TowerDefense;
            tdModel.CurrentTime = model.TimeModel.RealTime - tdModel.StartTime;
        }
    }
}