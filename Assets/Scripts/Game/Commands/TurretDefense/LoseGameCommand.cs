using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class LoseGameCommand : ICommand
    {
        public void Execute(GameModel model)
        {
            model.TurretDefenseModel.CurrentWave = -1;
            Debug.Log("Game over!!");
        }
    }
}
