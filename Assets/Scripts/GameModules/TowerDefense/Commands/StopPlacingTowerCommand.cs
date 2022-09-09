using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TowerDefense.Models;
using Model;

namespace TowerDefense.Commands
{
    public class StopPlacingTowerCommand : ICommand
    {
        public void Execute(GameModel model)
        {
            model.GetModel<TowerDefenseGameModel>().BuildingBeingPlaced = null;
        }
    }
}