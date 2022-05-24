using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class StopPlacingTowerCommand : ICommand
    {
        public void Execute(GameModel model)
        {
            model.TurretDefenseModel.BuildingBeingPlaced = null;
        }
    }
}