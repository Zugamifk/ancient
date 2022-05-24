using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            model.TowerDefense.BuildingBeingPlaced = _towerName;
        }
    }
}