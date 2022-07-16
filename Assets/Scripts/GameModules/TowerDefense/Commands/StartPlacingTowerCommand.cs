using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TowerDefense.Models;

namespace TowerDefense
{
    public class StartPlacingTowerCommand : ICommand
    {
        string _towerName;
        public StartPlacingTowerCommand(string towerName)
        {
            _towerName = towerName;
        }

        public void Execute(GameModel model)
        {
            model.GetModel<TowerDefenseGameModel>().BuildingBeingPlaced = _towerName;
        }
    }
}