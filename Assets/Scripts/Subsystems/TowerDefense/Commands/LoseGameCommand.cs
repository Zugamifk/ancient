using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense.Commands
{
    public class LoseGameCommand : ICommand
    {
        public void Execute(GameModel model)
        {
            model.TowerDefense.CurrentWave = -1;
            Debug.Log("Game over!!");
        }
    }
}
