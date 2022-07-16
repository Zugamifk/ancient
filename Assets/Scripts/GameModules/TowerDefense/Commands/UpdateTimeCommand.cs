using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TowerDefense.Models;

namespace TowerDefense.Commands
{
    public class UpdateTimeCommand : ICommand
    {
        public void Execute(GameModel model)
        {
            var tdModel = model.GetModel<TowerDefenseGameModel>();
            tdModel.CurrentTime = model.TimeModel.RealTime - tdModel.StartTime;
        }
    }
}