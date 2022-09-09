using System.Collections;
using System.Collections.Generic;
using TowerDefense.Models;
using UnityEngine;
using Model;

namespace TowerDefense.Commands
{
    public class LoseGameCommand : ICommand
    {
        public void Execute(GameModel model)
        {
            model.GetModel<TowerDefenseGameModel>().CurrentWave = -1;
            Debug.Log("Game over!!");
        }
    }
}
