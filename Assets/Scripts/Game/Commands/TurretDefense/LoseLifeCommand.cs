using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class LoseLifeCommand : ICommand
    {
        public void Execute(GameModel model)
        {
            var tdModel = model.TurretDefenseModel;
            tdModel.Lives--;
            if (tdModel.Lives <= 0)
            {
                Game.Do(new LoseGameCommand());
            }
        }
    }
}