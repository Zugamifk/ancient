using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense.Commands
{
    public class LoseLifeCommand : ICommand
    {
        public void Execute(GameModel model)
        {
            var tdModel = model.TowerDefense;
            tdModel.Lives--;
            if (tdModel.Lives <= 0)
            {
                Game.Do(new LoseGameCommand());
            }
        }
    }
}