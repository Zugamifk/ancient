using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TowerDefense.Behaviours;

namespace TowerDefense.Commands
{
    public class UpdateTowerFiringCommand : ICommand
    {
        static TowerBehaviour _towerBehaviour = new();
        Guid _id;
        public UpdateTowerFiringCommand(Guid id) => _id = id;

        public void Execute(GameModel model)
        {
            _towerBehaviour.UpdateFiringState(model, model.TowerDefense.Towers.GetItem(_id));
        }
    }
}
