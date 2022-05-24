using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense.Commands
{
    public class StopPlacingTowerCommand : ICommand
    {
        public void Execute(GameModel model)
        {
            model.TowerDefense.BuildingBeingPlaced = null;
        }
    }
}